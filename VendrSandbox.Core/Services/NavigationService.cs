using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.ViewModels.Shared;
using System;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace VendrSandbox.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Func<IPublishedContent, bool> _visible = x => x.IsVisible();

        public NavigationViewModel GetPrimaryNavigation(IPublishedContent model)
        {
            if (model == null) return null;

            var homepage = model.AncestorOrSelf<Homepage>();
            if (homepage == null) return null;

            var primaryNavigation = homepage?.PrimaryNavigation?.Where(_visible);
            if (primaryNavigation == null) return null;

            return new NavigationViewModel
            {
                CurrentPage = model,
                Items = primaryNavigation.Select(x => Map(x, model))
            };
        }

        public NavigationViewModel GetSiteMap(IPublishedContent model)
        {
            if (model == null) return null;

            var homepage = model.AncestorOrSelf<Homepage>();
            if (homepage == null) return null;

            var siteMap = homepage?.Children?.Where(_visible);

            return new NavigationViewModel
            {
                CurrentPage = model,
                Items = siteMap.Select(x => Map(x, model))
            };
        }

        public NavigationViewModel GetBreadcrumbs(IPublishedContent model)
        {
            if (model == null) return null;

            var breadcrumbs = model
                .AncestorsOrSelf()?                
                .Reverse();

            if (breadcrumbs == null) return null;

            return new NavigationViewModel
            {
                CurrentPage = model,
                Items = breadcrumbs.Select(x => Map(x, model))
            };
        }

        private NavigationItemViewModel Map(IPublishedContent model, IPublishedContent currentPage)
        {           
            var item = new NavigationItemViewModel
            {
                Url = model.Url,
                TemplateId = model.TemplateId,
                Title = model.HasValue("title") ? model.Value<string>("title") : model.Name,
                IsAncestor = model.IsAncestorOrSelf(currentPage),
                IsCurrent = model.Id == currentPage.Id
            };

            if (model is ISettings) 
                item.HideChildrenFromNavigation = Settings.GetHideChildrenFromNavigation(model as ISettings);

            if (model.Children?.Any() ?? false)
            {
                item.HasChildren = true;
                item.Children = model.Children?
                    .Where(_visible)?
                    .Select(x => Map(x, currentPage));
            }

             
            return item;
        }
    }
}
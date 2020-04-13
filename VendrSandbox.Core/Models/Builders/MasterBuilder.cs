using System;
using System.Linq;
using Umbraco.Web;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.Custom;
using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.ViewModels.Chrome;
using VendrSandbox.Core.ViewModels.JavaScript;

namespace VendrSandbox.Core.Models.Builders
{
    public class MasterBuilder : IBuilder<Master>
    {
        private readonly INavigationService _navigationService;

        public MasterBuilder(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        public Master Build(Master model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var homepage = model.GetHomepage();
            if (homepage == null) return model;

            model.Homepage = homepage;
            model.MetaData = MapMetaData(model);
            model.Header = MapHeader(model);
            model.JavaScript = MapJavaScript(model);
            model.Cookie = MapCookie(model);
            model.Footer = MapFooter(model);
            model.Breadcrumbs = MapBreadcrumbs(model);

            return model;
        }

        private MetaDataViewModel MapMetaData(Master model)
        {
            var viewModel = new MetaDataViewModel
            {
                FacebookPixelCode = model.Homepage.FacebookPixelCode,
                GoogleSiteVerificationCode = model.Homepage.GoogleSiteVerificationCode,
                GoogleTagManagerCode = model.Homepage.GoogleTagManagerCode
            };

            if (model is IMetaInfo)
                viewModel.SeoSettings = MetaInfo.GetSeoSettings(model as IMetaInfo);

            return viewModel;
        }

        private HeaderViewModel MapHeader(Master model)
        {
            var viewModel = new HeaderViewModel
            {
                HomepageUrl = model.Homepage.Url,
                LogoTop = model.Homepage.TopLogo as Image,
                PrimaryNavigation = _navigationService.GetPrimaryNavigation(model),
                CartPage = model.GetCartPage()
            };

            return viewModel;
        }

        private JavaScriptViewModel MapJavaScript(Master model)
        {
            return new JavaScriptViewModel
            {
                GoogleTagManagerCode = model.Homepage.GoogleTagManagerCode
            };
        }

        private CookieViewModel MapCookie(Master model)
        {
            return new CookieViewModel
            {
            };
        }

        private FooterViewModel MapFooter(Master model)
        {
            return new FooterViewModel
            {
                HomepageUrl = model.Homepage.Url,
                LogoBottom = model.Homepage.BottomLogo as Image,
                Copyright = model.Homepage.Copyright,
                FooterLinks = model.Homepage.FooterLinks?.Select(x => new LinkExtended(x))
            };
        }

        private BreadcrumbsViewModel MapBreadcrumbs(Master model)
        {
            return new BreadcrumbsViewModel
            {
                Breadcrumbs = _navigationService.GetBreadcrumbs(model)
            };
        }
    }
}

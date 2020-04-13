using VendrSandbox.Core.ViewModels;
using VendrSandbox.Core.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace VendrSandbox.Core.Interfaces
{
    public interface INavigationService
    {
        NavigationViewModel GetPrimaryNavigation(IPublishedContent model);
        NavigationViewModel GetSiteMap(IPublishedContent model);
        NavigationViewModel GetBreadcrumbs(IPublishedContent model);
    }
}

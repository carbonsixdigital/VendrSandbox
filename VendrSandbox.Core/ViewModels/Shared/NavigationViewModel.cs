using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace VendrSandbox.Core.ViewModels.Shared
{
    public class NavigationViewModel
    {
        public IPublishedContent CurrentPage { get; set; }
        public IEnumerable<NavigationItemViewModel> Items { get; set; }       
    }
}

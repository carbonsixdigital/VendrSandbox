using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace VendrSandbox.Core.ViewModels.Shared
{
    public class NavigationItemViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public int? TemplateId { get; set; }
        public bool HideChildrenFromNavigation { get; set; }
        public IEnumerable<NavigationItemViewModel> Children { get; set; }
        public bool IsAncestor { get; set; }
        public bool HasChildren { get; set; }
        public bool IsCurrent { get; set; } 
    }
}

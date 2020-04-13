using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace VendrSandbox.Core.Models.Custom
{
    public class LinkExtended
    {
        public IPublishedContent Content { get; set; }
        public string Title { get; set; }
        public string Target { get; set; }
        public LinkType Type { get; set; }
        public Udi Udi { get; set; }
        public string Url { get; set; }

        public LinkExtended(Link link)
        {
            if (link != null)
            {
                var helper = DependencyResolver.Current.GetService<UmbracoHelper>();
                if (helper != null)
                {
                    Target = link.Target;
                    Type = link.Type;
                    Udi = link.Udi;
                    Url = link.Url;
                    Content = link.Udi != null ? helper.Content(Udi) : null;
                    Title = link.Name;
                }
            }
        }
        public bool IsExternal() => Type == LinkType.External;
        public string TargetAttribute() => IsExternal() ? $"target='{Target}'" : string.Empty;
    }
}

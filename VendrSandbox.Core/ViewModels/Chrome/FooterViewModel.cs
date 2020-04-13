using VendrSandbox.Core.Models.Custom;
using VendrSandbox.Core.Models.DocumentTypes;
using System.Collections.Generic;

namespace VendrSandbox.Core.ViewModels.Chrome
{
    public class FooterViewModel
    {
        public string HomepageUrl { get; set; } 
        public Image LogoBottom { get; set; }
        public string Copyright { get; set; }
        public IEnumerable<LinkExtended> FooterLinks { get; set; }
    }
}

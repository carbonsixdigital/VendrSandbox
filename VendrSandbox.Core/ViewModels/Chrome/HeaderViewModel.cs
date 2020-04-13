using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendrSandbox.Core.ViewModels.Chrome
{
    public class HeaderViewModel
    {
        public Image LogoTop { get; set; } 
        public string HomepageUrl { get; set; }
        public NavigationViewModel PrimaryNavigation { get; set; }           
        public CartPage CartPage { get; set; } 
    }
}

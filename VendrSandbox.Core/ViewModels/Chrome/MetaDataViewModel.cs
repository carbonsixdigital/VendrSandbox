using SEOChecker.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendrSandbox.Core.ViewModels.Chrome
{
   public class MetaDataViewModel
    {
        public string GoogleTagManagerCode { get; set; }
        public string FacebookPixelCode { get; set; }
        public string GoogleSiteVerificationCode { get; set; }
        public MetaData SeoSettings { get; set; }
    }
}

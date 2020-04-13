using VendrSandbox.Core.ViewModels.Chrome;
using VendrSandbox.Core.ViewModels.JavaScript;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class Master
    {
        public Homepage Homepage { get; set; } 
        public HeaderViewModel Header { get; set; }
        public FooterViewModel Footer { get; set; }
        public JavaScriptViewModel JavaScript { get; set; }
        public CookieViewModel Cookie { get; set; }
        public MetaDataViewModel MetaData { get; set; }
        public BreadcrumbsViewModel Breadcrumbs { get; set; }
        public int CachedPartialDuration { get; set; }
        public string CachePrefix { get; set; }
    }
}
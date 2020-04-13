using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendrSandbox.Core.ViewModels.Shared
{
    public class PageModel
    {
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool IsFirstPage => PageNumber <= 1;
        public bool IsLastPage => PageNumber >= TotalPages;
    }
}
 
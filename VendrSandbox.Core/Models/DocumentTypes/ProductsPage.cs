using System.Collections.Generic;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class ProductsPage
    {
        public IEnumerable<IProductGroup> Items { get; set; }      
    }
}
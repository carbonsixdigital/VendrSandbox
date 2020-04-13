using System.Collections.Generic;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CollectionPage
    {
        public IEnumerable<ProductPage> Items { get; set; }      
    }
}
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Vendr.Core.Models;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class ProductPage
    {
        public CollectionPage Collection { get; set; }

        public IPublishedContent PrimaryImage { get; set; }

        public IEnumerable<ProductVariant> Variants { get; set; }

        public IEnumerable<Price> VariantPrices { get; set; }

        public bool VariantPricesAllSame { get; set; }

        public FormattedPrice VariantPriceFirst { get; set; }
    }
}

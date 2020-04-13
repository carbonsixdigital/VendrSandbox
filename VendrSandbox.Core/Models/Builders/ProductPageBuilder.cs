using System;
using System.Linq;
using Vendr.Core;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class ProductPageBuilder : IBuilder<ProductPage>
    {
        public ProductPage Build(ProductPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.Collection = model.Parent as CollectionPage;
            
            model.PrimaryImage = model.Images.FirstOrDefault();

            model.Variants = model.Children?.OfType<ProductVariant>()?.Where(x => x.IsPublished());
          
            if (model.Variants?.Any() ?? false)            
                model.VariantPrices = model.Variants.Select(x => x.CalculatePrice())?.OrderBy(x => x.WithoutTax)?.ToList();
            
            if (model.VariantPrices?.Any() ?? false)
            {
                model.VariantPricesAllSame = model.VariantPrices.All(x => x.WithoutTax == model.VariantPrices.FirstOrDefault()?.WithoutTax);
                model.VariantPriceFirst = model.VariantPrices.FirstOrDefault()?.Formatted();
            }

            return model;
        }
    }
}
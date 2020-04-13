using System;
using System.Linq;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class ProductsPageBuilder : IBuilder<ProductsPage>
    {
        public ProductsPage Build(ProductsPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.Items = model.Children
                .OfType<IProductGroup>()
                .Where(x => x.IsPublished() && x.TemplateId > 0);

            return model;
        }
    }
}
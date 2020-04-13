using System;
using System.Linq;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class CollectionPageBuilder : IBuilder<CollectionPage>
    {
        private readonly IBuilder<ProductPage> _productBuilder;

        public CollectionPageBuilder(IBuilder<ProductPage> productBuilder)
        {
            _productBuilder = productBuilder ?? throw new ArgumentNullException(nameof(productBuilder));
        }   
  
        public CollectionPage Build(CollectionPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.Items = model.Children
                .OfType<ProductPage>()
                .Where(x => x.IsPublished() && x.TemplateId > 0)
                .Select(_productBuilder.Build);

            return model;
        }

    }
}
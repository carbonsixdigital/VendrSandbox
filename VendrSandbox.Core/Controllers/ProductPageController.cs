using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class ProductPageController : MasterController
    {
        private readonly IBuilder<ProductPage> _builder;
        public ProductPageController(IBuilder<Master> masterBuilder, IBuilder<ProductPage> builder)
            : base(masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as ProductPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

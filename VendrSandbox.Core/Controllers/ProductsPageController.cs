using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class ProductsPageController : MasterController
    {
        private readonly IBuilder<ProductsPage> _builder;
        public ProductsPageController(IBuilder<Master> masterBuilder, IBuilder<ProductsPage> builder)
            : base(masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as ProductsPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

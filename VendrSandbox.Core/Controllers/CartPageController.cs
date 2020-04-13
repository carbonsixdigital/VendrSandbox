using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CartPageController : MasterController
    {
        private readonly IBuilder<CartPage> _builder;
        public CartPageController(IBuilder<Master> masterBuilder, IBuilder<CartPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CartPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

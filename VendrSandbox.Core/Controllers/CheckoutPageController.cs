using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CheckoutPageController : MasterController
    {
        private readonly IBuilder<CheckoutPage> _builder;
        public CheckoutPageController(IBuilder<Master> masterBuilder, IBuilder<CheckoutPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CheckoutPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

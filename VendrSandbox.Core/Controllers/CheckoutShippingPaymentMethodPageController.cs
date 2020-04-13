using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CheckoutShippingPaymentMethodPageController : MasterController
    {
        private readonly IBuilder<CheckoutShippingPaymentMethodPage> _builder;
        public CheckoutShippingPaymentMethodPageController(IBuilder<Master> masterBuilder, IBuilder<CheckoutShippingPaymentMethodPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CheckoutShippingPaymentMethodPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

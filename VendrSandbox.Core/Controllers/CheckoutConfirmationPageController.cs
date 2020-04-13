using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CheckoutConfirmationPageController : MasterController
    {
        private readonly IBuilder<CheckoutConfirmationPage> _builder;
        public CheckoutConfirmationPageController(IBuilder<Master> masterBuilder, IBuilder<CheckoutConfirmationPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CheckoutConfirmationPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

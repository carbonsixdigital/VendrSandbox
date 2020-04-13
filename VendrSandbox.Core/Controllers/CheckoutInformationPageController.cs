using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CheckoutInformationPageController : MasterController
    {
        private readonly IBuilder<CheckoutInformationPage> _builder;
        public CheckoutInformationPageController(IBuilder<Master> masterBuilder, IBuilder<CheckoutInformationPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CheckoutInformationPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CheckoutReviewPageController : MasterController
    {
        private readonly IBuilder<CheckoutReviewPage> _builder;
        public CheckoutReviewPageController(IBuilder<Master> masterBuilder, IBuilder<CheckoutReviewPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CheckoutReviewPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

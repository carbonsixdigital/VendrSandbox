using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using System;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class CollectionPageController : MasterController
    {
        private readonly IBuilder<CollectionPage> _builder;
        public CollectionPageController(IBuilder<Master> masterBuilder, IBuilder<CollectionPage> builder) 
            : base (masterBuilder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as CollectionPage);
            return base.Index(new ContentModel(viewModel));
        }
    }
}

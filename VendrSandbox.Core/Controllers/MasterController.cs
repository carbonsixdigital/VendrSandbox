using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.Builders;
using VendrSandbox.Core.Models.DocumentTypes;
using System;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace VendrSandbox.Core.Controllers
{
    public class MasterController : RenderMvcController
    {
        private readonly IBuilder<Master> _builder;
        public MasterController(IBuilder<Master> builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = _builder.Build(model.Content as Master); 
            return base.Index(new ContentModel(viewModel));
        }
    }
}

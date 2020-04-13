using VendrSandbox.Core.Interfaces;
using System.Web.Mvc;
using Umbraco.Web.Models;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Controllers
{
    public class HomepageController : MasterController
    {
        public HomepageController(IBuilder<Master> masterBuilder) 
            : base (masterBuilder)
        {
        }

        public override ActionResult Index(ContentModel model)
        {
            return base.Index(model);
        }
    }
}

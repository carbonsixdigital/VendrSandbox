using VendrSandbox.Core.Controllers;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace VendrSandbox.Core.Composers
{
    public class BaseControllerComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.SetDefaultRenderMvcController(typeof(MasterController));
        }
    }
}
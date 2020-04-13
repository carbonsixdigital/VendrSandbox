using System.Net;
using System.Web.Helpers;
using Umbraco.Core.Composing;

namespace VendrSandbox.Core.Composers
{
    public class SecurityComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
        }
    }  
}


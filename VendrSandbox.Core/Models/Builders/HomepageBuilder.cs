using System;
using System.Linq;
using Umbraco.Web;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class HomepageBuilder : IBuilder<Homepage>
    {
        public Homepage Build(Homepage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));           
            return model;
        }
    }
}
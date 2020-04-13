using System;
using System.Linq;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class CheckoutPageBuilder : IBuilder<CheckoutPage>
    {
        public CheckoutPage Build(CheckoutPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.Order = model.GetCurrentOrder(); 

            return model;
        }
    }
}
using System;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Models.Builders
{
    public class CartPageBuilder : IBuilder<CartPage>
    {
        public CartPage Build(CartPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.CheckoutPage = model.GetCheckoutPage();
            model.Order = model.GetCurrentOrder();

            return model;
        }
    }
}
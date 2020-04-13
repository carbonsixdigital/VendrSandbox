using System;
using System.Linq;
using Vendr.Core.Api;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.ViewModels.Checkout;

namespace VendrSandbox.Core.Models.Builders
{
    public class CheckoutShippingPaymentMethodPageBuilder : IBuilder<CheckoutShippingPaymentMethodPage>
    {
        public CheckoutShippingPaymentMethodPage Build(CheckoutShippingPaymentMethodPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.CheckoutPage = model.GetCheckoutPage();
            model.Order = model.GetCurrentOrder();
            model.ShippingMethods = VendrApi.Instance.GetShippingMethods(model.GetStore().Id);
            model.PaymentMethods = VendrApi.Instance.GetPaymentMethods(model.GetStore().Id);

            var steps = model.GetCheckoutPage()?.GetSteps();
            if (steps != null)
                model.Steps = new StepsViewModel(steps, model.Id);

            return model;
        }
    }
}
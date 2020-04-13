using System;
using System.Linq;
using Vendr.Core.Api;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.ViewModels.Checkout;

namespace VendrSandbox.Core.Models.Builders
{
    public class CheckoutConfirmationPageBuilder : IBuilder<CheckoutConfirmationPage>
    {
        public CheckoutConfirmationPage Build(CheckoutConfirmationPage model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            model.CheckoutPage = model.GetCheckoutPage();
            var order = VendrApi.Instance.GetCurrentFinalizedOrder(model.GetStore().Id);            
            if (order != null)
            {
                model.Order = order;
                model.PaymentCountry = VendrApi.Instance.GetCountry(order.PaymentInfo.CountryId.Value);
                model.ShippingCountry = VendrApi.Instance.GetCountry(order.ShippingInfo.CountryId.Value);
            }

            var steps = model.GetCheckoutPage()?.GetSteps();
            if (steps != null)
                model.Steps = new StepsViewModel(steps, model.Id);

            return model;
        }
    }
}
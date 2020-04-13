﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Vendr.Core;
using Vendr.Core.Services;
using Vendr.Core.Session;
using VendrSandbox.Core.Dtos;
using VendrSandbox.Core.Extensions;

namespace VendrSandbox.Core.Controllers.SurfaceControllers
{
    public class CheckoutSurfaceController : SurfaceController, IRenderController
    {
        private readonly ISessionManager _sessionManager;
        private readonly IOrderService _orderService;
        private readonly IUnitOfWorkProvider _uowProvider;

        public CheckoutSurfaceController(ISessionManager sessionManager,
            IOrderService orderService,
            IUnitOfWorkProvider uowProvider)
        {
            _sessionManager = sessionManager;
            _orderService = orderService;
            _uowProvider = uowProvider;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyDiscountOrGiftCardCode(DiscountOrGiftCardCodeDto model)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)?
                        .AsWritable(uow)?
                        .Redeem(model.Code);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to redeem discount code");
                return CurrentUmbracoPage();
            }

             return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveDiscountOrGiftCardCode(DiscountOrGiftCardCodeDto model)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow)
                        .Unredeem(model.Code);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Failed to redeem discount code");

                return CurrentUmbracoPage();
            }

            return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrderInformation(UpdateOrderInformationDto model)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow)
                        .SetProperties(new Dictionary<string, string>
                        {
                            { Constants.Properties.Customer.EmailPropertyAlias, model.Email },
                            { "marketingOptIn", model.MarketingOptIn ? "1" : "0" },

                            { Constants.Properties.Customer.FirstNamePropertyAlias, model.BillingAddress.FirstName },
                            { Constants.Properties.Customer.LastNamePropertyAlias, model.BillingAddress.LastName },
                            { "billingAddressLine1", model.BillingAddress.Line1 },
                            { "billingAddressLine2", model.BillingAddress.Line2 },
                            { "billingCity", model.BillingAddress.City },
                            { "billingZipCode", model.BillingAddress.ZipCode },
                            { "billingTelephone", model.BillingAddress.Telephone },

                            { "shippingSameAsBilling", model.ShippingSameAsBilling ? "1" : "0" },
                            { "shippingFirstName", model.ShippingSameAsBilling ? model.BillingAddress.FirstName : model.ShippingAddress.FirstName },
                            { "shippingLastName", model.ShippingSameAsBilling ? model.BillingAddress.LastName : model.ShippingAddress.LastName },
                            { "shippingAddressLine1", model.ShippingSameAsBilling ? model.BillingAddress.Line1 : model.ShippingAddress.Line1 },
                            { "shippingAddressLine2", model.ShippingSameAsBilling ? model.BillingAddress.Line2 : model.ShippingAddress.Line2 },
                            { "shippingCity", model.ShippingSameAsBilling ? model.BillingAddress.City : model.ShippingAddress.City },
                            { "shippingZipCode", model.ShippingSameAsBilling ? model.BillingAddress.ZipCode : model.ShippingAddress.ZipCode },
                            { "shippingTelephone", model.ShippingSameAsBilling ? model.BillingAddress.Telephone : model.ShippingAddress.Telephone },

                            { "comments", model.Comments },
                            { "ipAddress", GetIPAddress() }

                        })
                        .SetPaymentCountryRegion(model.BillingAddress.Country, null)
                        .SetShippingCountryRegion(model.ShippingSameAsBilling ? model.BillingAddress.Country : model.ShippingAddress.Country, null);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to update information");
                return CurrentUmbracoPage();
            }

            if (model.NextStep.HasValue)
                return RedirectToUmbracoPage(model.NextStep.Value);

            return RedirectToCurrentUmbracoPage();
        }

        private string GetIPAddress()
        {
            var context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                    return addresses[0];
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrderShippingAndPaymentMethod(UpdateOrderShippingPaymentMethodDto model)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow)
                        .SetShippingMethod(model.ShippingMethod)
                        .SetPaymentMethod(model.PaymentMethod);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Failed to shipping / payment method");
                return CurrentUmbracoPage();
            }

            if (model.NextStep.HasValue)
                return RedirectToUmbracoPage(model.NextStep.Value);

            return RedirectToCurrentUmbracoPage();
        }
    }
}

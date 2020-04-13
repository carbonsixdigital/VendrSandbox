﻿using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Vendr.Core;
using Vendr.Core.Exceptions;
using Vendr.Core.Services;
using Vendr.Core.Session;
using VendrSandbox.Core.Dtos;
using VendrSandbox.Core.Extensions;

namespace VendrSandbox.Core.Controllers.SurfaceControllers
{
    public class CartSurfaceController : SurfaceController
    {
        private readonly ISessionManager _sessionManager;
        private readonly IOrderService _orderService;
        private readonly IUnitOfWorkProvider _uowProvider;

        public CartSurfaceController(ISessionManager sessionManager,
            IOrderService orderService,
            IUnitOfWorkProvider uowProvider)
        {
            _sessionManager = sessionManager;
            _orderService = orderService;
            _uowProvider = uowProvider;
        }

        [ChildActionOnly]
        public ActionResult CartCount()
        {
            var store = CurrentPage.GetStore();
            var order = _sessionManager.GetCurrentOrder(store.Id);

            return PartialView("~/Views/Partials/Chrome/CartCount.cshtml", order?.TotalQuantity ?? 0);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(AddToCartDto postModel)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow)
                        .AddProduct(postModel.ProductReference, 1);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch (ValidationException)
            {
                ModelState.AddModelError("productReference", "Failed to add product to cart");

                return CurrentUmbracoPage();
            }

            TempData["addedProductReference"] = postModel.ProductReference;

            return RedirectToCurrentUmbracoPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCart(UpdateCartDto postModel)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow);

                    foreach (var orderLine in postModel.OrderLines)
                    {
                        order.WithOrderLine(orderLine.Id)
                            .SetQuantity(orderLine.Quantity);
                    }

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch (ValidationException)
            {
                ModelState.AddModelError("productReference", "Failed to update cart");

                return CurrentUmbracoPage();
            }

            TempData["cartUpdated"] = "true";

            return RedirectToCurrentUmbracoPage();
        }

        [HttpGet]        
        public ActionResult RemoveFromCart(RemoveFromCartDto postModel)
        {
            try
            {
                using (var uow = _uowProvider.Create())
                {
                    var store = CurrentPage.GetStore();
                    var order = _sessionManager.GetOrCreateCurrentOrder(store.Id)
                        .AsWritable(uow)
                        .RemoveOrderLine(postModel.OrderLineId);

                    _orderService.SaveOrder(order);

                    uow.Complete();
                }
            }
            catch (ValidationException)
            {
                ModelState.AddModelError("productReference", "Failed to remove cart item");

                return CurrentUmbracoPage();
            }

            return RedirectToCurrentUmbracoPage();
        }
    }
}

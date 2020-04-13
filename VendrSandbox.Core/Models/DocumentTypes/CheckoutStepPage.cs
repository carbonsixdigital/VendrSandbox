using System.Collections.Generic;
using Vendr.Core.Models;
using VendrSandbox.Core.ViewModels.Checkout;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutStepPage
    {
        public CheckoutPage CheckoutPage { get; set; }
        public virtual OrderReadOnly Order { get; set; }  
        public PaymentMethodReadOnly PaymentMethod { get; set; }
        public ShippingMethodReadOnly ShippingMethod { get; set; }
        public CartPage CartPage { get; set; }
        public StepsViewModel Steps { get; set; }
    }
}


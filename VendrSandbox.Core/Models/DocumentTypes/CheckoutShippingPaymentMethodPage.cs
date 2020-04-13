using System.Collections.Generic;
using Vendr.Core.Models;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutShippingPaymentMethodPage
    {
        public IEnumerable<ShippingMethodReadOnly> ShippingMethods { get; set; }

        public IEnumerable<PaymentMethodReadOnly> PaymentMethods { get; set; }
    }
}


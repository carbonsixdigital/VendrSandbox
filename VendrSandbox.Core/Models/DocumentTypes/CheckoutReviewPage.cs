using Vendr.Core.Models;
using VendrSandbox.Core.Interfaces;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutReviewPage : IOrderReviewPage
    {
        public CountryReadOnly PaymentCountry { get; set; }

        public CountryReadOnly ShippingCountry { get; set; }
    }
}


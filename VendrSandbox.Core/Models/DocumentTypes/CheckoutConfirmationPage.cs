using Vendr.Core.Models;
using VendrSandbox.Core.Interfaces;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutConfirmationPage : IOrderReviewPage
    {
        public override OrderReadOnly Order { get; set; } 

        public CountryReadOnly PaymentCountry { get; set; }

        public CountryReadOnly ShippingCountry { get; set; }
    }
}

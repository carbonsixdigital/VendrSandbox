using Vendr.Core.Models;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CartPage
    {
        public CheckoutPage CheckoutPage { get; set; }
        public OrderReadOnly Order { get; set; }
    }
}

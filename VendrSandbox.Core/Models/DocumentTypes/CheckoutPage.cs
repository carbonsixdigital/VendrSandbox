using System.Collections.Generic;
using Vendr.Core.Models;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutPage
    {
        public OrderReadOnly Order { get; set; }

        public IEnumerable<CheckoutStepPage> Steps { get; set; }
    }
}


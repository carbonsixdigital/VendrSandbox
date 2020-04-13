using System.Collections.Generic;
using VendrSandbox.Core.Extensions;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.ViewModels.Checkout
{
    public class StepsViewModel
    {
        public StepsViewModel(IEnumerable<CheckoutStepPage> steps, int id)
        {
            Items = steps;
            Previous = steps?.Previous(id);
            Next = steps?.Next(id);
        }

        public IEnumerable<CheckoutStepPage> Items { get; internal set; }
        public CheckoutStepPage Previous { get; internal set; }
        public CheckoutStepPage Next { get; internal set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendr.Core.Models;

namespace VendrSandbox.Core.Interfaces
{
    public interface IOrderReviewPage
    {
        OrderReadOnly Order { get; }

        CountryReadOnly PaymentCountry { get; }

        CountryReadOnly ShippingCountry { get; }
    }
}

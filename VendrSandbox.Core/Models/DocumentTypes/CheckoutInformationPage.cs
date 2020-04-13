using System.Collections.Generic;
using Vendr.Core.Models;

namespace VendrSandbox.Core.Models.DocumentTypes
{
    public partial class CheckoutInformationPage
    {        
        public IEnumerable<CountryReadOnly> Countries { get; set; }
    }
}


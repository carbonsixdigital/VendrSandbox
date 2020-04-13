using System;

namespace VendrSandbox.Core.Dtos
{
    public class UpdateCartDto
    {
        public OrderLineQuantityDto[] OrderLines { get; set; }
    }

    public class OrderLineQuantityDto
    {
        public Guid Id { get; set; }

        public decimal Quantity { get; set; }
    }
}

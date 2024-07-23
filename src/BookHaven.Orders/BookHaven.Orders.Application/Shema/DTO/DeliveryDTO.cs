using System;

namespace BookHaven.Orders.Application.Shema.DTO
{
    public record DeliveryDTO
    {
        public Guid Key { get; internal set; }
        public string? Status { get; set; }
    }
}

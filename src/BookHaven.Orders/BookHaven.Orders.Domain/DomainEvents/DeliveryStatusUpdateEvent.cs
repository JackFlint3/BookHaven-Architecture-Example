using BookHaven.Core.Domain.Intefaces;
using BookHaven.Orders.Domain.Entities;

namespace BookHaven.Orders.Domain.DomainEvents
{
    public class DeliveryStatusUpdateEvent : IDomainEvent
    {
        public required Delivery Delivery { get; init; }
        public required string NewStatus { get; init; }
    }
}

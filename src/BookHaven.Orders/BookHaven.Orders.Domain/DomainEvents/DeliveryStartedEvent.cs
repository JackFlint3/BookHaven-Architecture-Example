using BookHaven.Core.Domain.Intefaces;
using BookHaven.Orders.Domain.Entities;

namespace BookHaven.Orders.Domain.DomainEvents
{
    public class DeliveryStartedEvent : IDomainEvent
    {
        public required Delivery Delivery { get; init; }
    }
}

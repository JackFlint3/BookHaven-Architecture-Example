using BookHaven.Core.Domain.Intefaces;
using BookHaven.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Domain.DomainEvents
{
    public class DeliveryStartedEvent : IDomainEvent
    {
        public required Delivery Delivery { get; init; }
    }
}

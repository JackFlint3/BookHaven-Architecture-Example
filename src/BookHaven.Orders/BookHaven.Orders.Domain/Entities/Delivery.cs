using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Domain.Intefaces;
using BookHaven.Orders.Domain.DomainEvents;
using System;
using System.Collections.Generic;

namespace BookHaven.Orders.Domain.Entities
{
    public abstract class Delivery : Entity<Guid>
    {
        public DateTime Departure { get; private set; }
        public string CarrierStatus { get; set; } = "";
        ICollection<ISBN> Publications { get; set; } = new List<ISBN>();
        public required Order Order { get; set; }

        public bool InProgress { get; set; }
        public bool Completed { get; set; }

        public abstract bool Accepts(ISBN iSBN);

        public void Add(ISBN isbn, int amount)
        {
            if (InProgress || Completed)
                throw new Exception("Cannot add items to delivery that is in progress or completed");

            for (int iPublication = 0; iPublication < amount; iPublication++)
            {
                Publications.Add(isbn);
            }
        }

        public virtual void Start()
        {
            if (InProgress || Completed)
                throw new Exception("Cannot start delivery of Item that is in progress or completed");

            if (Publications is null || Publications.Count <= 0)
                throw new Exception($"At least one {nameof(ISBN)} is required to start a delivery");

            InProgress = true;
        }

        public virtual void End()
        {
            InProgress = false;
            Completed = true;
        }

        public void UpdateCarrierStatus(string newStatus)
        {
            var root = Order as IDomainEventKeeper;
            root.RegisterEvent(new DeliveryStatusUpdateEvent() { Delivery = this, NewStatus = newStatus });

            CarrierStatus = newStatus;
        }

    }
}

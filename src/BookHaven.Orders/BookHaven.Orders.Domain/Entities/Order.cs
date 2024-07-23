using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BookHaven.Orders.Domain.Entities
{
    public class Order : AggregateRoot<Guid, Order>
    {
        public Destination? Destination { get; private set; }
        public bool IsDispatched { get; set; }
        public ICollection<Delivery> Deliveries { get; private set; } = new List<Delivery>();

        public void AddItem(ISBN isbn, int amount)
        {
            if (IsDispatched)
                throw new Exception("Cannot add items to an order that already is in transit");

            var query = from delivery in Deliveries
                        where delivery.Accepts(isbn)
                        select delivery;

            if (query.Any())
                query.First().Add(isbn, amount);
            else {
                Delivery newDelivery = isbn switch
                {
                    EPUB or PDF => new DownloadDelivery() { Order = this },
                    Print => new CarrierDelivery() { Order = this },
                    _ => throw new Exception($"Unknown Delivery type for ISBN of type {isbn.GetType().Name}"),
                };

                newDelivery.Add(isbn, amount);
                Deliveries.Add(newDelivery);
            }
        }


        public void SetDestination(Destination destination)
        {
            if (IsDispatched)
                throw new Exception("Cannot change destination of an order that already is in transit");


            Destination = destination;
        }

        public void Dispatch()
        {
            if (IsDispatched)
                throw new Exception("Cannot dispatch an order that has already been dispatched");


            IsDispatched = true;

            foreach (var delivery in Deliveries)
            {
                delivery.Start();
            }
        }
    }
}

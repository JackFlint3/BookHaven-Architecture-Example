using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Domain.Intefaces;
using BookHaven.Orders.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Domain.Entities
{
    public class CarrierDelivery : Delivery
    {
        public override bool Accepts(ISBN iSBN)
        {
            if (iSBN is Print)
                return true;

            return false;
        }

        public override void Start()
        {
            base.Start();
            var root = Order as IDomainEventKeeper;
            root.RegisterEvent(new DeliveryStartedEvent() { Delivery = this });
        }
    }
}

using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHaven.Accounts.Domain.Entities
{
    public class Basket : Entity<Guid>
    {
        public ICollection<BasketItem> Items { get; private set; }

        public void AddItem(ISBN publication, int amount)
        {
            var item = Items.FirstOrDefault(i => i.Publication == publication);
            if (item is not null)
                item.Amount += amount;
            else
                Items.Add(new BasketItem() { Amount = amount, Publication = publication});
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void RemoveItem(ISBN publication)
        {
            var items = Items.Where(i => i.Publication == publication);

            foreach (var item in items)
                Items.Remove(item);
        }
    }
}

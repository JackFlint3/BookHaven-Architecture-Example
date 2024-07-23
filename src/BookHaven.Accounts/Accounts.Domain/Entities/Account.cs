using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Orders.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookHaven.Accounts.Domain.Entities
{
    public class Account : AggregateRoot<Email, Account>
    {
        public Basket Basket { get; set; } = new Basket();
        public Address? Address { get; set; }
        public Phonenumber? Phone { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public string Name { get; set; }
        string Password { get; set; }

        public bool Is2FAEnabled => Phone is not null;
        public bool CanPurchase => Address is not null;

        public Account(Email email, string password) : base(email)
        {
            this.Password = password;
        }


        public bool MatchesPassword(string password)
        {
            return Password == password;
        }

        public void AddBookToBasket(ISBN publication, int amount = 1)
        {
            Basket.AddItem(publication, amount);
        }

        public Order PlaceOrder()
        {
            var order = new Order();

            foreach (var item in Basket.Items)
            {
                order.AddItem(item.Publication, item.Amount);
            }

            ArgumentNullException.ThrowIfNull(Address);

            order.SetDestination(new Destination() with
            {
                HouseAddress = Address.HouseAddress,
                City = Address.City,
                StreetName = Address.StreetName,
                Recipient = Name
            });

            order.Dispatch();

            Basket.Clear();

            return order;
        }
    }
}

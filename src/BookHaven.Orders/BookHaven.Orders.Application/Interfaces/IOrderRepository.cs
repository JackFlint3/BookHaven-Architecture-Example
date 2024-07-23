using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Domain.Entities;
using System;

namespace BookHaven.Orders.Application.Interfaces
{
    public interface IOrderRepository : ICQUDRepository<Order, Guid>
    {
    }
}

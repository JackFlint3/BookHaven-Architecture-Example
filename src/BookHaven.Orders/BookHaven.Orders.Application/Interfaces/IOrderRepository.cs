using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Application.Interfaces
{
    public interface IOrderRepository : ICQUDRepository<Order, Guid>
    {
    }
}

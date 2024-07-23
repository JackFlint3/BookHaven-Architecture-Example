using BookHaven.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Application.Interfaces
{
    public interface ICarrierUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
    }
}

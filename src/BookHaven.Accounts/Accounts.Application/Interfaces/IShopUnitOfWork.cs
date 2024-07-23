using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IShopUnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IBookRepository BookRepository { get; }
        public IOrderRepository OrderRepository { get; }
    }
}

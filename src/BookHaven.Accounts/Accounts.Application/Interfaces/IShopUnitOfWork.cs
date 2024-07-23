using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Application.Interfaces;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IShopUnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IBookRepository BookRepository { get; }
        public IOrderRepository OrderRepository { get; }
    }
}

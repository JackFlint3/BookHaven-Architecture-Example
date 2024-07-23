using BookHaven.Core.Application.Interfaces;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }

    }
}

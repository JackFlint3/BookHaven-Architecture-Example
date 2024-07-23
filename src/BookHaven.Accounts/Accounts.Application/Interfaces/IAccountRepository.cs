using BookHaven.Accounts.Domain.Entities;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Entities;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IAccountRepository : ICQUDRepository<Account, Email>
    {
    }
}

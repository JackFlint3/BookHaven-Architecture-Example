using BookHaven.Accounts.Domain.Entities;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Interfaces
{
    public interface IRequestingUserAccessor
    {
        Task<Account?> GetRequestingUserAsync();
        Task SetRequestingUserAsync(Account account);
    }
}

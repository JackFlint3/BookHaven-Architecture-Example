using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Domain.Entities;
using BookHaven.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Infrastructure.RequestingUser
{
    internal class RequestingUserAccessor : IRequestingUserAccessor
    {
        IHttpContextAccessor Accessor { get; set; }
        IUnitOfWorkFactory<IAccountUnitOfWork> UnitOfWorkFactory { get; set; }
        public RequestingUserAccessor(IHttpContextAccessor accessor, IUnitOfWorkFactory<IAccountUnitOfWork> unitOfWorkFactory)
        {
            Accessor = accessor;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        const string REQUESTING_USER_LOCATION = "location";
        public async Task<Account?> GetRequestingUserAsync()
        {
            var session = Accessor.HttpContext.Session;
            if (!session.IsAvailable) await session.LoadAsync();
            if (session.TryGetValue(REQUESTING_USER_LOCATION, out var requestingUserIdentity))
            {
                var email = System.Text.Encoding.Default.GetString(requestingUserIdentity);
                using var unitOfWork = UnitOfWorkFactory.Create();
                var account = (await unitOfWork.AccountRepository.FindByQueryAsync(a => a.Key.Equals(email))).FirstOrDefault();
                return account;
            }
            else return null;


        }

        public async Task SetRequestingUserAsync(Account account)
        {
            var session = Accessor.HttpContext.Session;
            if (!session.IsAvailable) await session.LoadAsync();
            session.Set(REQUESTING_USER_LOCATION, Encoding.Default.GetBytes(account.Key.Value));

            await session.CommitAsync();
        }
    }
}

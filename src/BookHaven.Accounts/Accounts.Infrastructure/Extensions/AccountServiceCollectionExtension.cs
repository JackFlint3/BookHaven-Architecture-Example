using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Infrastructure.Emails;
using BookHaven.Accounts.Infrastructure.MessageBroker;
using BookHaven.Accounts.Infrastructure.Persistence.EFCore;
using BookHaven.Accounts.Infrastructure.RequestingUser;
using BookHaven.Core.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BookHaven.Accounts.Infrastructure.Extensions
{
    public static class AccountServiceCollectionExtension
    {
        public static IServiceCollection AddAccounts(this IServiceCollection serviceDescriptors)
        {
            // configure DI
            //serviceDescriptors.AddBaseDbContext<ShopDbContext>();
            serviceDescriptors.AddDbContextFactory<ShopDbContext>((provider, options) => options.UseApplicationDatabase(provider));
            serviceDescriptors.AddUnitOfWorkFactory<ShopDbContext, IShopUnitOfWork>();
            serviceDescriptors.AddUnitOfWorkFactory<ShopDbContext, IAccountUnitOfWork>();
            serviceDescriptors.AddSingleton<IEmailService, DummyEmailService>();
            serviceDescriptors.AddTransient<IRequestingUserAccessor, RequestingUserAccessor>();
            serviceDescriptors.AddSingleton<IMessageBroker, DummyMessageBroker>();

            return serviceDescriptors;
        }
    }
}

using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class CoreServiceCollectionExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceDescriptors)
        {
            // configure DI
            serviceDescriptors.AddDbContextFactory<CoreDbContext>((provider, options) => options.UseApplicationDatabase(provider));
            serviceDescriptors.AddUnitOfWorkFactory<CoreDbContext, ICoreUnitOfWork>();
            return serviceDescriptors;
        }
    }
}

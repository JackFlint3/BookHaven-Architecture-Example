using BookHaven.Core.Infrastructure.Extensions;
using BookHaven.Orders.Application.Interfaces;
using BookHaven.Orders.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookHaven.Orders.Infrastructure.Extensions
{
    public static class OrdersServiceCollectionExtension
    {
        public static IServiceCollection AddOrders(this IServiceCollection serviceDescriptors)
        {
            // configure DI
            //serviceDescriptors.AddBaseDbContext<CarrierDbContext>();
            serviceDescriptors.AddDbContextFactory<CarrierDbContext>((provider, options) => options.UseApplicationDatabase(provider));
            serviceDescriptors.AddUnitOfWorkFactory<CarrierDbContext, ICarrierUnitOfWork>();

            return serviceDescriptors;
        }
    }
}

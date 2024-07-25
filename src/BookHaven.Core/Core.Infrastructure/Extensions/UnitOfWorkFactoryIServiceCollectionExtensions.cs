using BookHaven.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class UnitOfWorkFactoryIServiceCollectionExtensions
    {
        private sealed class UnitOfWorkFactory<TDbContext, TUnitOfWork> : IUnitOfWorkFactory<TUnitOfWork>
            where TUnitOfWork : IUnitOfWork
            where TDbContext : DbContext
        {
            IDbContextFactory<TDbContext> DbContextFactory { get; set; }

            public UnitOfWorkFactory(IDbContextFactory<TDbContext> dbContextFactory)
            {
                this.DbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            }

            public TUnitOfWork Create()
            {
                throw new NotImplementedException();
            }
        }
        public static IServiceCollection AddUnitOfWorkFactory<TDbContext, TUnitOfWork>(this IServiceCollection serviceDescriptors)
            where TUnitOfWork : IUnitOfWork
            where TDbContext : DbContext
        {
            serviceDescriptors.AddTransient<IUnitOfWorkFactory<TUnitOfWork>>(
                    p => new UnitOfWorkFactory<TDbContext, TUnitOfWork>(p.GetRequiredService<IDbContextFactory<TDbContext>>())
                );

            return serviceDescriptors;
        }
    }
}

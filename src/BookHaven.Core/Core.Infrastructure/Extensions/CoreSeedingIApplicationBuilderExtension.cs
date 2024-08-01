using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class CoreSeedingIApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCoreSeeding(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWorkFactory<ICoreUnitOfWork>>();

            CoreSeeds.Seed(uow.Create()).GetAwaiter().GetResult();

            return app;
        }
    }
}

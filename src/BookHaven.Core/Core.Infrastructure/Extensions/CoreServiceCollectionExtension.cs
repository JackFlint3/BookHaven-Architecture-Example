using BookHaven.Core.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class CoreServiceCollectionExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceDescriptors)
        {
            // configure DI
            serviceDescriptors.AddBaseDbContext<CoreDbContext>();
            serviceDescriptors.AddDbContextFactory<CoreDbContext>((provider, options) => options.UseApplicationDatabase(provider));

            return serviceDescriptors;
        }
    }
}

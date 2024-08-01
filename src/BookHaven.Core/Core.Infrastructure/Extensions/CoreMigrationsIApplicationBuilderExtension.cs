using BookHaven.Core.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class CoreMigrationsIApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCoreMigrations(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var s = scope.ServiceProvider.GetRequiredService<IDbContextFactory<CoreDbContext>>();

            var dbcontext = s.CreateDbContext();
#if DEBUG
            dbcontext.Database.EnsureCreated();
#else
            dbcontext.Database.Migrate();
#endif
            dbcontext.SaveChanges();

            return builder;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations
{
    public static class AuthorConfigurationExtension
    {
        public static ModelBuilder AddAuthorConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            return modelBuilder;
        }
    }
}

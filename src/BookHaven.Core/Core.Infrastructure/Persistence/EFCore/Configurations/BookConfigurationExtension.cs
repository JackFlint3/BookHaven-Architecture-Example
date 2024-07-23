using Microsoft.EntityFrameworkCore;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations
{
    public static class BookConfigurationExtension
    {
        public static ModelBuilder AddBookConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            return modelBuilder;
        }
    }
}

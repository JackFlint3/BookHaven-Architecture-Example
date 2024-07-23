using BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Orders.Infrastructure.Persistence.EFCore.Configurations
{
    public static class OrderConfigurationExtension
    {
        public static ModelBuilder AddOrderConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            return modelBuilder;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BookHaven.Accounts.Infrastructure.Persistence.EFCore.Configurations
{
    public static class AccountConfigurationExtension
    {
        public static ModelBuilder AddAccountConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            return modelBuilder;
        }
    }
}

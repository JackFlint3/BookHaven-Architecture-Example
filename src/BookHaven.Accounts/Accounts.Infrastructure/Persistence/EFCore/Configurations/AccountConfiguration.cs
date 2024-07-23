using BookHaven.Accounts.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHaven.Accounts.Infrastructure.Persistence.EFCore.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(b => b.Key);
        }
    }
}

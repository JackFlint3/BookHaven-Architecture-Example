using BookHaven.Core.Domain.Entities.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Key);

            builder.HasOne(b => b.Cover)
                .WithOne();

            builder.HasMany(b => b.Authors)
                .WithMany("Books");
        }
    }
}

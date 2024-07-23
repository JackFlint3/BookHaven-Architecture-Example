using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Shared;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore
{
    public class CoreDbContext : BaseDbContext
    {
        DbSet<Author> Authors { get; init; }
        DbSet<Book> Books { get; init; }

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
            Books = this.Set<Book>();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddBookConfiguration();
            modelBuilder.AddAuthorConfiguration();
        }
    }
}

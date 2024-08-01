using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore
{
    public class CoreDbContext : BaseDbContext, ICoreUnitOfWork
    {
        DbSet<Author> Authors { get; init; }
        DbSet<Book> Books { get; init; }

        public ICQUDRepository<Book, Guid> BookRepository => DbSetRepositoryWrapper<Book, Guid>.Wrap(Books)
            .With([nameof(Book.Genres),nameof(Book.Publications),nameof(Book.Authors)]);

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

using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Domain.Entities;
using BookHaven.Accounts.Infrastructure.Persistence.EFCore.Configurations;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Entities;
using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations;
using BookHaven.Core.Infrastructure.Persistence.EFCore.Shared;
using BookHaven.Orders.Application.Interfaces;
using BookHaven.Orders.Domain.Entities;
using BookHaven.Orders.Infrastructure.Persistence.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookHaven.Accounts.Infrastructure.Persistence.EFCore
{
    internal class ShopDbContext : BaseDbContext, IAccountUnitOfWork, IShopUnitOfWork
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Order> Orders { get; set; }

        public ShopDbContext(DbContextOptions options) : base(options)
        {
            Accounts = this.Set<Account>();
            Books = this.Set<Book>();
            Orders = this.Set<Order>();
        }

        public IAccountRepository AccountRepository =>
            DbSetRepositoryWrapper<Account, Email>.Wrap(Accounts) as IAccountRepository
            ?? throw new Exception($"Set for Entity {Accounts} not configured");

        public IBookRepository BookRepository =>
            DbSetRepositoryWrapper<Book, Guid>.Wrap(Books) as IBookRepository
            ?? throw new Exception($"Set for Entity {Books} not configured");

        public IOrderRepository OrderRepository =>
            DbSetRepositoryWrapper<Order, Guid>.Wrap(Orders) as IOrderRepository
            ?? throw new Exception($"Set for Entity {Orders} not configured");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddBookConfiguration();
            modelBuilder.AddAccountConfiguration();
            modelBuilder.AddOrderConfiguration();

        }
    }
}

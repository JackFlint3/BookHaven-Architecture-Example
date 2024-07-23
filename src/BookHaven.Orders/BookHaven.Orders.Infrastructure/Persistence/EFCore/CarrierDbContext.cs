using BookHaven.Core.Infrastructure.Persistence.EFCore.Shared;
using BookHaven.Orders.Application.Interfaces;
using BookHaven.Orders.Domain.Entities;
using BookHaven.Orders.Infrastructure.Persistence.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Infrastructure.Persistence.EFCore
{
    internal class CarrierDbContext : BaseDbContext, ICarrierUnitOfWork
    {
        DbSet<Order> Orders { get; set; }

        public CarrierDbContext(DbContextOptions options) : base(options)
        {
            Orders = this.Set<Order>();
        }

        public IOrderRepository OrderRepository =>
            DbSetRepositoryWrapper<Order, Guid>.Wrap(Orders) as IOrderRepository
            ?? throw new Exception($"Set for Entity {Orders} not configured");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddOrderConfiguration();

        }
    }
}

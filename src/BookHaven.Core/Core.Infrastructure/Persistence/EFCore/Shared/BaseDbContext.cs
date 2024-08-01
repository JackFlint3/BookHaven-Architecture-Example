using BookHaven.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Shared
{
    public abstract class BaseDbContext : DbContext, IUnitOfWork
    {


        private IDbContextTransaction? _transaction;

        public BaseDbContext(DbContextOptions options) : base(options) { }

        public void Begin()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Rollback()
            => _transaction?.Rollback();

        public void Commit()
        {
            ArgumentNullException.ThrowIfNull(_transaction);

            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
        }

        public async Task CommitAsync()
        {
            ArgumentNullException.ThrowIfNull(_transaction);

            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }

        public override void Dispose()
        {
            _transaction?.Dispose();
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            _transaction?.Dispose();
            return base.DisposeAsync();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // Dispatch DomainEvents here


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

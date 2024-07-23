using BookHaven.Core.Application.Interfaces;
using BookHaven.Core.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Shared
{
    public class DbSetRepositoryWrapper<TEntity, TKey> : ICQUDRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TEntity, TKey>, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        DbSet<TEntity>? WrappingSet {  get; set; }

        private DbSetRepositoryWrapper(DbSet<TEntity> wrappingSet)
        {
            WrappingSet = wrappingSet;
        }

        public IEnumerable<TEntity> AsEnumerable()
        {
            ArgumentNullException.ThrowIfNull(WrappingSet);
            return WrappingSet.AsEnumerable();
        }

        public async Task CreateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(WrappingSet);
            // with how async functions, this is less than ideal but required due to DbSet Constraints
            await WrappingSet.AddAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(WrappingSet);
            WrappingSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(WrappingSet);
            WrappingSet.Update(entity);
            return Task.CompletedTask;
        }


        void IDisposable.Dispose()
        {
            WrappingSet = null;
        }

        public static DbSetRepositoryWrapper<TEntity, TKey> Wrap(DbSet<TEntity> set)
            => new DbSetRepositoryWrapper<TEntity, TKey>(set);
    }
}

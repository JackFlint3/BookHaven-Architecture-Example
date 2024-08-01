using BookHaven.Core.Domain.Intefaces;
using System;

namespace BookHaven.Core.Application.Interfaces
{
    public interface ICQUDRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>, ICUDRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}

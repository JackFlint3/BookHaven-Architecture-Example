using BookHaven.Core.Domain.Intefaces;
using System;

namespace BookHaven.Core.Application.Interfaces
{
    public interface ICQUDRepository<TAggregate, TKey> : IQueryRepository<TAggregate, TKey>, ICUDRepository<TAggregate, TKey>
        where TAggregate : IAggregateRoot<TAggregate, TKey>, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}

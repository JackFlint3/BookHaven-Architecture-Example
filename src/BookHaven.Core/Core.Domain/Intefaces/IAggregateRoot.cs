using BookHaven.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookHaven.Core.Domain.Intefaces
{
    public interface IAggregateRoot<TEntity, TKey> : IDomainEventKeeper
        where TEntity : IEntity<TKey>
    {

    }
}

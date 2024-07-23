using BookHaven.Core.Domain.Intefaces;
using System;
using System.Collections.Generic;

namespace BookHaven.Core.Domain.Entities
{
    public abstract class AggregateRoot<TKey, TRoot>
        : Entity<TKey>, IAggregateRoot<TRoot, TKey>
        where TRoot : Entity<TKey>
    {
        ICollection<IDomainEvent> IDomainEventKeeper.DomainEvents { get; set; }

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(TKey key) : base(key)
        {
            
        }

    }
}

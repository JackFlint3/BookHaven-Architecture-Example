using BookHaven.Core.Domain.Intefaces;
using System.Collections.Generic;

namespace BookHaven.Core.Domain.Entities
{
    public abstract class AggregateRoot<TKey>
        : Entity<TKey>, IAggregateRoot<TKey>
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

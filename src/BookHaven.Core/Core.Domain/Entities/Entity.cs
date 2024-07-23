using BookHaven.Core.Domain.Intefaces;
using System;

namespace BookHaven.Core.Domain.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Key { get; protected internal set; }

        protected Entity() : this(default) { }

        protected Entity(TKey key)
        {
            Key = key;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().IsAssignableTo(this.GetType())
                && obj is Entity<TKey> entity
                && entity.Key.Equals(this.Key))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }
    }
}

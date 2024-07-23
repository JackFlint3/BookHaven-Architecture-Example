using System;

namespace BookHaven.Core.Domain.Entities.BookAggregate
{
    public record Genre
    {
        public string Name { get; private set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

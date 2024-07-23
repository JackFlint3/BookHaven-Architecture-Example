using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHaven.Core.Domain.Entities.BookAggregate
{
    public class Book : AggregateRoot<Guid, Book>
    {
        public Cover Cover { get; private set; }
        public IReadOnlyCollection<ISBN> Publications { get; private set; }
        public IReadOnlyCollection<Author> Authors { get; private set; }
        public IReadOnlyCollection<Genre> Genres { get; private set; }

        public void AddPublication(ISBN publication)
        {
            if (Publications.Any(p => p.GetType().Equals(publication.GetType())))
                throw new System.Exception($"Cannot add a publication of the same type to {this}");

            var newPublications = Publications.Append(publication);
            Publications = newPublications.ToList();
        }
    }
}
using BookHaven.Core.Domain.Intefaces;
using System;

namespace BookHaven.Core.Domain.Entities.BookAggregate
{
    public class Author : Entity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

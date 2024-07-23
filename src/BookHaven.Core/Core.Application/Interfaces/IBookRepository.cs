using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Domain.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface IBookRepository : IQueryRepository<Book, Guid>
    {
        Task<Book?> GetByISBNAsync(string ISBN) => 
            Task.FromResult(this.FindAsEnumerable(b => b.Publications.Any(p => p.Equals(ISBN))).FirstOrDefault());
        Task<Book?> GetByGuidAsync(Guid id) => 
            Task.FromResult(this.FindAsEnumerable(b => b.Key == id).FirstOrDefault());
    }
}

using BookHaven.Core.Domain.Entities.BookAggregate;
using BookHaven.Core.Domain.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface IBookRepository : IQueryRepository<Book, Guid>
    {
        async Task<Book?> GetByISBNAsync(string ISBN) =>
            (await this.FindByQueryAsync(b => b.Publications.Any(p => p.Equals(ISBN)))).FirstOrDefault();
        async Task<Book?> GetByGuidAsync(Guid id) =>
            (await this.FindByQueryAsync(b => b.Publications.Any(p => p.Equals(id)))).FirstOrDefault();
    }
}

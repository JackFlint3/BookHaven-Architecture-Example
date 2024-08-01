using BookHaven.Core.Domain.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface ICoreUnitOfWork : IUnitOfWork
    {
        ICQUDRepository<Book, Guid> BookRepository { get; }
    }
}

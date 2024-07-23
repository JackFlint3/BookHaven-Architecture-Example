using BookHaven.Core.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface ICUDRepository<in TEntity, TKey> 
        where TEntity : IEntity<TKey>
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

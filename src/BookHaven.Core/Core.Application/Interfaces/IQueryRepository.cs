using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookHaven.Core.Domain.Intefaces
{
    public interface IQueryRepository<TEntity, TKey> : IDisposable
        where TEntity : IEntity<TKey>
    {
        Task<ICollection<TEntity>> FindByQueryAsync(Expression<Func<TEntity, bool>> predicate, string[] includedProperties = null);
    }
}

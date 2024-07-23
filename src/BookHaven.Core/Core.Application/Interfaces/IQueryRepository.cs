using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace BookHaven.Core.Domain.Intefaces
{
    public interface IQueryRepository<TAggregate, TKey> : IDisposable
        where TAggregate : IAggregateRoot<TAggregate,TKey>, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TAggregate> AsEnumerable();

        public TAggregate? GetByKey(TKey key) => AsEnumerable().Where(aggregate => aggregate?.Key?.Equals(key) ?? false).FirstOrDefault();
        public IEnumerable<TAggregate> FindAsEnumerable(Func<TAggregate, bool> predicate) => AsEnumerable().Where(predicate).ToList();
    }
}

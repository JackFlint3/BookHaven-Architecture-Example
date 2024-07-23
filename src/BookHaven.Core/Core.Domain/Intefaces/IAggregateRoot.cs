namespace BookHaven.Core.Domain.Intefaces
{
    public interface IAggregateRoot<TEntity, TKey> : IDomainEventKeeper
        where TEntity : IEntity<TKey>
    {

    }
}

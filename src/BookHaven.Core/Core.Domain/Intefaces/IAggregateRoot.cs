namespace BookHaven.Core.Domain.Intefaces
{
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IDomainEventKeeper
    {

    }
}

namespace BookHaven.Core.Domain.Intefaces
{
    public interface IEntity<TKey>
    {
        public TKey Key { get; }
    }
}

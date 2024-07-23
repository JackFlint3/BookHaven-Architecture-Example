namespace BookHaven.Core.Application.Interfaces
{
    public interface IUnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork Create();
    }
}

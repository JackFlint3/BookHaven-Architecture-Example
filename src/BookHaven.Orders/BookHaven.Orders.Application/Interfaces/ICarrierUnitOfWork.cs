using BookHaven.Core.Application.Interfaces;

namespace BookHaven.Orders.Application.Interfaces
{
    public interface ICarrierUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
    }
}

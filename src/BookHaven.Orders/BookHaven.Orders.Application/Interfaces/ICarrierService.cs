using BookHaven.Orders.Application.Shema.DTO;
using System.Threading.Tasks;

namespace BookHaven.Orders.Domain.Interfaces
{
    public interface ICarrierService
    {
        Task FailDeliveryAsync(DeliveryDTO delivery);
        Task UpdateDeliveryAsync(DeliveryDTO delivery);
    }
}

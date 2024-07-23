using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Application.Interfaces;
using BookHaven.Orders.Application.Shema.DTO;
using BookHaven.Orders.Domain.DomainEvents;
using BookHaven.Orders.Domain.Entities;
using BookHaven.Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Orders.Application.Services
{
    public class CarrierService : ICarrierService, IDomainEventHandler<DeliveryStartedEvent>
    {
        IUnitOfWorkFactory<ICarrierUnitOfWork> UnitOfWorkFactory { get; set; }

        public CarrierService(IUnitOfWorkFactory<ICarrierUnitOfWork> unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task FailDeliveryAsync(DeliveryDTO delivery)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var order = unitOfWork.OrderRepository.FindAsEnumerable(o => o.Deliveries.Any(d => d.Key == delivery.Key)).FirstOrDefault()
                ?? throw new Exception("Cannot update status for nonexistent Delivery");
            var failingDelivery = order.Deliveries.Where(d => d.Key == delivery.Key).First();
            failingDelivery.UpdateCarrierStatus("Failed");
            failingDelivery.End();

            await unitOfWork.CommitAsync();
        }

        public async Task UpdateDeliveryAsync(DeliveryDTO delivery)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var order = unitOfWork.OrderRepository.FindAsEnumerable(o => o.Deliveries.Any(d => d.Key == delivery.Key)).FirstOrDefault()
                ?? throw new Exception("Cannot update status for nonexistent Delivery");
            var updatingDelivery = order.Deliveries.Where(d => d.Key == delivery.Key).First();
            updatingDelivery.UpdateCarrierStatus(delivery.Status ?? "");

            await unitOfWork.CommitAsync();
        }

        public async Task HandleAsync(DeliveryStartedEvent @event)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();
            unitOfWork.Begin();

            var order = unitOfWork.OrderRepository.FindAsEnumerable(o => o.Deliveries.Any(d => d.Key == @event.Delivery.Key)).FirstOrDefault()
                ?? throw new Exception("Cannot update status for nonexistent Delivery");
            var startingDelivery = order.Deliveries.Where(d => d.Key == @event.Delivery.Key).First();
            startingDelivery.UpdateCarrierStatus("Started");

            await unitOfWork.CommitAsync();
        }
    }
}

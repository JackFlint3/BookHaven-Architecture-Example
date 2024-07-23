using BookHaven.Accounts.Application.Interfaces;
using BookHaven.Accounts.Application.Schema.DTO;
using BookHaven.Core.Application.Interfaces;
using BookHaven.Orders.Domain.DomainEvents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookHaven.Accounts.Application.Services
{
    public class DeliveryUpdateEventHandler : IDomainEventHandler<DeliveryStatusUpdateEvent>
    {
        public required IUnitOfWorkFactory<IAccountUnitOfWork> UnitOfWorkFactory { get; set; }
        public required IEmailService EmailService { get; set; }

        public DeliveryUpdateEventHandler(IUnitOfWorkFactory<IAccountUnitOfWork> unitOfWorkFactory, IEmailService emailService)
        {
            UnitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            EmailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task HandleAsync(DeliveryStatusUpdateEvent @event)
        {
            using var unitOfWork = UnitOfWorkFactory.Create();

            var account = unitOfWork.AccountRepository.FindAsEnumerable(a => a.Orders.Any(o => o.Deliveries.Any(d => d.Key == @event.Delivery.Key))).FirstOrDefault()
                ?? throw new Exception($"No account attributed to delivery {@event.Delivery.Key}");

            EmailDto email = new() { Content = @event.NewStatus, Email = account.Key.Value };

            await EmailService.SendEmailAsync(email);
        }
    }
}

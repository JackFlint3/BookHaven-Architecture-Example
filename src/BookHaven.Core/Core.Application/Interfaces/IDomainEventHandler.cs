using BookHaven.Core.Domain.Intefaces;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface IDomainEventHandler<TEvent>
        where TEvent : IDomainEvent
    {
        public Task HandleAsync(TEvent @event);
    }
}

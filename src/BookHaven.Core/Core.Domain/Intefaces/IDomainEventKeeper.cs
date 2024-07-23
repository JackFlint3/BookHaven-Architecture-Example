using System.Collections.Generic;
using System.Linq;

namespace BookHaven.Core.Domain.Intefaces
{
    public interface IDomainEventKeeper
    {
        ICollection<IDomainEvent> DomainEvents { get; protected set; }

        void RegisterEvent(IDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }

        IReadOnlyCollection<IDomainEvent> PopEvents()
        {
            var events = DomainEvents.ToList();

            DomainEvents.Clear();

            return events;
        }
    }
}

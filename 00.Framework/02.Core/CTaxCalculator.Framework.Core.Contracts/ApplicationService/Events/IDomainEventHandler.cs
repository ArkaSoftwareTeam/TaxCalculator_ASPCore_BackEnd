using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Framework.Core.Contracts.ApplicationService.Events
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent Event);
    }
}

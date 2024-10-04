using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Framework.Core.Contracts.ApplicationService.Events
{
    public interface IDomainEventDispatcher
    {
        Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
    }
}

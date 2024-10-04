using CTaxCalculator.Framework.Core.Contracts.ApplicationService.Events;
using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Framework.Core.ApplicationServices.Events
{
    public abstract class EventDispatcherDecorator : IDomainEventDispatcher
    {
        #region Fields
        protected IDomainEventDispatcher _eventDispatcher;
        public abstract int Order { get; }
        #endregion

        #region Constructors
        public EventDispatcherDecorator() { }
        #endregion

        #region Abstract Send Commands
        public abstract Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;

        public void SetEventDispatcher(IDomainEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
        }
        #endregion
    }


}

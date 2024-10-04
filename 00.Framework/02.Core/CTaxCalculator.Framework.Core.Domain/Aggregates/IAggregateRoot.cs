using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Framework.Core.Domain.Aggregates
{
    public interface IAggregateRoot
    {
        void ClearEvents();
        IEnumerable<IDomainEvent> GetEvents();
    }
}

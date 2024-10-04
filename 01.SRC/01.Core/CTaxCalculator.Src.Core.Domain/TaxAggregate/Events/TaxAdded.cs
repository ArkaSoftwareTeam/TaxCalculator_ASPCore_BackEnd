using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record TaxAdded(DateTime PassageDateTime) : IDomainEvent
    {
    }
}

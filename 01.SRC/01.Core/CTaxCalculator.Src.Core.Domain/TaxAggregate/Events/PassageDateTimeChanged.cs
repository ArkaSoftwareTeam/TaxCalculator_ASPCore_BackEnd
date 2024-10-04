using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record PassageDateTimeChanged(long PassageId , DateTime NewDateTime):IDomainEvent
    {
    }
}

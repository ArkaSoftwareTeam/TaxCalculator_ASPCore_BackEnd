using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record TaxRuleAdded(TimeOnly StartDateTime , TimeOnly EndDateTime , decimal Amount):IDomainEvent
    {
    }
}

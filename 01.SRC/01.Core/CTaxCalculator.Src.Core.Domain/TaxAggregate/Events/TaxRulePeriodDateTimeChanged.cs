using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record TaxRulePeriodDateTimeChanged(long TaxRuleId, TimeOnly StartTime , TimeOnly EndTime) : IDomainEvent
    {

    }
}

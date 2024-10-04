using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record TaxTotalPriceIncremented(long VehicleId, decimal TaxAmount) : IDomainEvent
    {

    }
}

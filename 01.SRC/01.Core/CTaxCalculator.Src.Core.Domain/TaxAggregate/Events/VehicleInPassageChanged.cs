using CTaxCalculator.Framework.Core.Domain.Events;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record VehicleInPassageChanged(long PassageId , long VehicleId) :IDomainEvent
    {

    }
}

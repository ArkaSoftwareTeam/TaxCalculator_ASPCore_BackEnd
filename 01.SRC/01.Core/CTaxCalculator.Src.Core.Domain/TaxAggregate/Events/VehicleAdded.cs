using CTaxCalculator.Framework.Core.Domain.Events;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Events
{
    public record VehicleAdded(TollFreeVehicles VehicleType , string PlateNumber , decimal AmountTax) : IDomainEvent
    {
    }
}

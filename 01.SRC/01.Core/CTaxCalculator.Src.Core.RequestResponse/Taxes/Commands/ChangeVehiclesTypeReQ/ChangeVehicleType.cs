using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesTypeReQ
{
    public class ChangeVehicleType : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long VehicleId { get; set; }
        public TollFreeVehiclesType VehicleType { get; set; }

        public string Path => "api/TaxCalculator/Vehicle/UpdateVehicleType";
    }
}

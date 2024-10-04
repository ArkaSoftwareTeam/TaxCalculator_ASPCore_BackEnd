using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesPlateNumberReQ
{
    public class ChangeVehiclePlateNumber : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long VehicleId { get; set; }
        public string VehiclePlateNumber { get; set; } = string.Empty;

        public string Path => "api/TaxCalculator/Passage/UpdateVehicle";
    }
}

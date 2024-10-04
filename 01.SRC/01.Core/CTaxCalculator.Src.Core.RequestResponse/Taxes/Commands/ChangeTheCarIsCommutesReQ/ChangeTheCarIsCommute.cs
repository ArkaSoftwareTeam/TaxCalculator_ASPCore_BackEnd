using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTheCarIsCommutesReQ
{
    public class ChangeTheCarIsCommute : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long PassageId { get; set; }
        public long VehicleId { get; set; }

        public string Path => "api/TaxCalculator/Passage/UpdateVehicle";
    }
}

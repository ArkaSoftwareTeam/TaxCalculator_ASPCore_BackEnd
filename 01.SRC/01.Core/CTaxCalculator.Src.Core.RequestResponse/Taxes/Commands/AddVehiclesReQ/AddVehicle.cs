using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddVehiclesReQ
{
    public class AddVehicle:ICommand<string> , IWebRequest
    {
        [SwaggerSchema("ID of the city where the vehicle is being registered")]
        public long CityId { get; set; }

        [SwaggerSchema("Type of the vehicle ( Motorcycle ,\r\n        Tractor ,\r\n        Emergency ,\r\n        Diplomat ,\r\n        Foreign ,\r\n        Military ,\r\n        Other = (Only this type includes tax))")]
        public string VehicleType { get; set; } = string.Empty;

        [SwaggerSchema("License plate number of the vehicle => With Pattern Is : {valid -> KJD258 ; notValid -> lak215 , kjd 215 , ... }")]
        public string PlateNumber { get; set; } = string.Empty;

        [SwaggerSchema("API endpoint path for adding a new vehicle => This Property Is Nullable.")]
        public string Path => "api/TaxCalculator/Vehicle/Add";
    }
}

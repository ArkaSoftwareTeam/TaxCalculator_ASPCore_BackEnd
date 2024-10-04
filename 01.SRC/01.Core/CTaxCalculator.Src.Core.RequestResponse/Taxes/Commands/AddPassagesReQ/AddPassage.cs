using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddPassagesReQ
{
    public class AddPassage:ICommand<object> , IWebRequest
    {
        [SwaggerSchema("ID of the city where the passage is being registered")]
        public long CityId { get; set; }

        [SwaggerSchema("ID of the vehicle associated with the passage")]
        public long VehicleId { get; set; }

        [SwaggerSchema("API endpoint path for adding a new passage")]
        public string Path => "api/TaxCalculator/Passage/Add";
    }
}

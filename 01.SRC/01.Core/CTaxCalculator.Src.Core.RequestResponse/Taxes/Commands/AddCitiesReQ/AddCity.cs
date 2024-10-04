using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddCitiesReQ
{
    public class AddCity:ICommand<object> , IWebRequest
    {
        [SwaggerSchema("Name of the city to be added")]
        public string CityName { get; set; } = string.Empty;

        [SwaggerSchema("API endpoint path for adding a new city")]
        public string Path => "api/TaxCalculate/City/Add";
    }
}

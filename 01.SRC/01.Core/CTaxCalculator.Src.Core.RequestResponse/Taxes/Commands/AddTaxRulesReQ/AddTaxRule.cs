using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddTaxRulesReQ
{
    public class AddTaxRule:ICommand<object> , IWebRequest
    {

        [SwaggerSchema("ID of the city where the TaxRule is registered")]
        public long CityId { get; set; }

        [SwaggerSchema("The start time of the tax law in the format (06:00:00)")]
        public TimeOnly StartTime { get; set; }

        [SwaggerSchema("End time of tax law with format (06:00:00)")]
        public TimeOnly EndTime { get; set; }

        [SwaggerSchema("The amount of tax that must be paid during these hours. Format (12)")]
        public decimal TaxAmount { get; set; }

        [SwaggerSchema("The address used to call this Endpoint, which does not require a value")]
        public string Path => "api/TaxCalculate/TaxRule/Add";
    }
}

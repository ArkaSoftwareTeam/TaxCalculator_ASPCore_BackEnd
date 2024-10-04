using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;
namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddFreeTaxDateTimeReQ
{
    public class AddFreeTaxDateTime:ICommand<object> , IWebRequest
    {
        [SwaggerSchema("ID of the city for which the free tax date is being added")]
        public long CityId { get; set; }

        [SwaggerSchema("Date and time when the tax is free")]
        public DateTime Date { get; set; }

        [SwaggerSchema("API endpoint path for adding a new free tax date and time")]
        public string Path => "api/TaxCalculator/FreeTaxDateTime/Add";
    }
}

using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeCityNameReQ
{
    /// <summary>
    /// Command to update the name of a city.
    /// </summary>
    public class UpdateCityName : ICommand, IWebRequest
    {
        /// <summary>
        /// The Id of the city to be Find And Updated.
        /// </summary>
        [SwaggerSchema("ID of the city where the Find And Change Name")]
        public long CityId { get; set; }


        /// <summary>
        /// The new name of the city to be updated.
        /// </summary>
        [SwaggerSchema("The new name of the city to be updated.")]
        public string CityName { get; set; } = string.Empty;

        /// <summary>
        /// The address used to call this endpoint.
        /// </summary>
        public string Path => "api/TaxCalculator/City/UpdateCityName";
    }
}

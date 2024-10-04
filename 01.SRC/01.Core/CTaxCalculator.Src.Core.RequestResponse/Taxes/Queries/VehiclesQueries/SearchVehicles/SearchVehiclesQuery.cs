using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles
{
    /// <summary>
    /// Represents a query for searching vehicles based on specific criteria.
    /// This class allows filtering of vehicles by type, plate number, and city name, while supporting pagination.
    /// </summary>
    public class SearchVehiclesQuery : PageQuery<PagedData<SearchVehiclesResQri>>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the type of vehicle to filter the search results.
        /// </summary>
        [SwaggerSchema("Type of the vehicle to filter the search results.")]
        public string? VehicleType { get; set; }



        /// <summary>
        /// Gets or sets the plate number of the vehicle to filter the search results.
        /// </summary>
        [SwaggerSchema("Plate number of the vehicle to filter the search results.")]
        public string? PlateNumber { get; set; }



        /// <summary>
        /// Gets or sets the name of the city to filter the search results.
        /// </summary>
        [SwaggerSchema("City name to filter the search results.")]
        public string? CityName { get; set; }



        /// <summary>
        /// Gets the address used to call this endpoint, which does not require a value.
        /// </summary>
        public string Path => "api/TaxCalculate/Vehicle/SearchBy";
    }
}

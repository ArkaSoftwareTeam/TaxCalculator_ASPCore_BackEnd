using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue
{
    /// <summary>
    /// Represents a query to retrieve a city based on its unique identifier.
    /// This class implements the <see cref="IQuery{CityQri}"/> interface 
    /// and is used in conjunction with the <see cref="IWebRequest"/> 
    /// interface to specify the API endpoint for retrieving city data.
    /// </summary>
    public class SearchCityQuery : PageQuery<PagedData<SearchCityQri>>, IWebRequest
    {
        [SwaggerSchema("Name of the city to be retrieved")]
        public string? CityName { get; set; } = string.Empty;


        /// <summary>
        /// Gets the API endpoint path for retrieving a city by its ID.
        /// This path is used to make requests to the server to fetch the city details.
        /// </summary>
        [SwaggerSchema("API endpoint path for retrieving a city by its ID")]
        public string Path => "api/TaxCalculate/City/SearchByInputValue";
    }
}

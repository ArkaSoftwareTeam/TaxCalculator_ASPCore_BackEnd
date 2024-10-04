using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById
{
    /// <summary>
    /// Represents a query to retrieve a city based on its unique identifier.
    /// This class implements the <see cref="IQuery{CityQri}"/> interface 
    /// and is used in conjunction with the <see cref="IWebRequest"/> 
    /// interface to specify the API endpoint for retrieving city data.
    /// </summary>
    public class GetCityByIdQuery : IQuery<CityQri>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the city to be retrieved.
        /// This identifier should correspond to an existing city in the system.
        /// </summary>
        [SwaggerSchema("ID of the city to be retrieved")]
        public long CityId { get; set; }



        /// <summary>
        /// Gets the API endpoint path for retrieving a city by its ID.
        /// This path is used to make requests to the server to fetch the city details.
        /// </summary>
        [SwaggerSchema("API endpoint path for retrieving a city by its ID")]
        public string Path => "api/TaxCalculate/City/GetById";
    }
}

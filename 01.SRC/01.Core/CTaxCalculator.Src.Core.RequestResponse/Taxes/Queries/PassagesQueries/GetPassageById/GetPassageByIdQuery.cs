using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById
{
    /// <summary>
    /// Represents a query to retrieve a Passage based on its unique identifier.
    /// This class implements the <see cref="IQuery{PassageQri}"/> interface 
    /// and is used in conjunction with the <see cref="IWebRequest"/> 
    /// interface to specify the API endpoint for retrieving Passage data.
    /// </summary>
    public class GetPassageByIdQuery : IQuery<PassageQri>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the city to be retrieved.
        /// This identifier should correspond to an existing city in the system.
        /// </summary>
        [SwaggerSchema("ID of the city to be retrieved")]
        public long CityId { get; set; }


        /// Gets or sets the unique identifier of the Passage to be retrieved.
        /// This identifier should correspond to an existing Passage in the system.
        /// </summary>
        [SwaggerSchema("ID of the Passage to be retrieved")]
        public long PassageId { get; set; }


        /// <summary>
        /// Gets the API endpoint path for retrieving a city by its ID.
        /// This path is used to make requests to the server to fetch the city details.
        /// </summary>
        [SwaggerSchema("API endpoint path for retrieving a Passage by its ID")]
        public string Path => "api/TaxCalculate/Passage/GetById";
    }
}

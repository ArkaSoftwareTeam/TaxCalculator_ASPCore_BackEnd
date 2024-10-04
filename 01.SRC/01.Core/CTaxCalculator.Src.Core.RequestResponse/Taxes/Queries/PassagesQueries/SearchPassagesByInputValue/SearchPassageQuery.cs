using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.SearchPassagesByInputValue
{
    /// <summary>
    /// Represents a query to retrieve a Passage based on its unique identifier.
    /// This class implements the <see cref="IQuery{SearchPassageQri}"/> interface 
    /// and is used in conjunction with the <see cref="IWebRequest"/> 
    /// interface to specify the API endpoint for retrieving Passage data.
    /// </summary>
    public class SearchPassageQuery : PageQuery<PagedData<SearchPassageQri>>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Passage to be retrieved.
        /// This identifier should correspond to an existing Passage in the system.
        /// </summary>
        [SwaggerSchema("ID of the Passage to be retrieved")]
        public long? PassageId { get; set; }



        [SwaggerSchema("Name of the Passage to be retrieved")]
        public DateTime? PassageDateTime { get; set; }


        /// <summary>
        /// Gets the API endpoint path for retrieving a Passage by its ID.
        /// This path is used to make requests to the server to fetch the Passage details.
        /// </summary>
        [SwaggerSchema("API endpoint path for retrieving a Passage by its ID")]
        public string Path => "api/TaxCalculate/Passage/SearchByInputValue";
    }
}

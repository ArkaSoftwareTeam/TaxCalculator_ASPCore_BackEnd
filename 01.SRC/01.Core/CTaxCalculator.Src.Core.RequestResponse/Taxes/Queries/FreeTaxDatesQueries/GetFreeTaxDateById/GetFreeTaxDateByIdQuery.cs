using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById
{

    /// <summary>
    /// Represents a query for retrieving a free tax date by its unique identifier.
    /// This class is used to fetch specific details of a free tax date from the API.
    /// </summary>
    /// <remarks>
    /// The <see cref="GetFreeTaxDateByIdQuery"/> class is utilized in the context of querying
    /// free tax date information within the application. It allows the client to specify the
    /// unique identifier of the free tax date they wish to retrieve, making it easier to
    /// access detailed information about that date through the API.
    /// </remarks>
    public class GetFreeTaxDateByIdQuery : IQuery<FreeTaxDateQri>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the free tax date.
        /// This ID is required to fetch the specific free tax date from the system.
        /// </summary>
        [SwaggerSchema("Unique identifier of the free tax date")]
        public long FreeTaxDateId { get; set; }

        /// <summary>
        /// Gets the API endpoint path for retrieving a free tax date by its ID.
        /// This path is used to make requests to the server to fetch the free tax date details.
        /// </summary>
        [SwaggerSchema("The address used to call this Endpoint, which does not require a value")]
        public string Path => "api/TaxCalculate/FreeTaxDate/GetById";
    }
}

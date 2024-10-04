using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll
{

    /// <summary>
    /// Represents a query to retrieve all free tax dates from the API.
    /// This class is used to encapsulate the request for fetching a list of free tax dates.
    /// </summary>
    public class GetFreeTaxDatesReadAllQuery : IQuery<List<FreeTaxDatesQri>>, IWebRequest
    {
        /// <summary>
        /// Gets the API endpoint path for retrieving all free tax dates.
        /// This path is used to make requests to the server to fetch all available free tax dates.
        /// </summary>
        [SwaggerSchema("The address used to call this Endpoint, which does not require a value")]
        public string Path => "api/TaxCalculate/FreeTaxDates/ReadAll";
    }
}

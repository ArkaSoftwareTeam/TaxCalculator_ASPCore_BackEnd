using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime
{

    /// <summary>
    /// Represents a query to search for free tax dates based on a specific date and time.
    /// This class encapsulates the request for retrieving free tax dates that match the given criteria.
    /// </summary>
    public class SearchFreeTaxDatesQuery : PageQuery<PagedData<FreeTaxDatesSearchQri>>, IWebRequest
    {

        /// <summary>
        /// Gets or sets the date and time to search for free tax dates.
        /// This value can be null, indicating that no specific date and time has been provided.
        /// </summary>
        [SwaggerSchema("The date and time to search for free tax dates. Can be null if no specific date and time is provided.")]
        public DateTime? DateTime { get; set; }


        /// <summary>
        /// Gets the API endpoint path for searching free tax dates by date and time.
        /// This path is used to make requests to the server to fetch free tax dates that match the specified date and time.
        /// </summary>
        public string Path => "api/TaxCalculate/FreeTaxDates/SearchByDateTime";
    }


    
}

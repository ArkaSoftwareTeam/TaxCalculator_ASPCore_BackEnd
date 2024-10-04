using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.SearchTaxRulesByInputValue
{
    /// <summary>
    /// Represents a query for retrieving a specific tax rule by its ID.
    /// This class implements the <see cref="IQuery{T}"/> interface to specify the expected return type
    /// and the <see cref="IWebRequest"/> interface to define the API endpoint for the query.
    /// </summary>
    public class SearchTaxRuleQuery : PageQuery<PagedData<SearchTaxRuleQri>>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the tax rule to retrieve.
        /// This ID is of integer type and is used to specify which tax rule is being requested.
        /// </summary>
        [SwaggerSchema("ID attribute of integer type is used to specify or read a specific tax law")]
        public long? TaxRuleId { get; set; }


        [SwaggerSchema("Start Time attribute of TimeOnly type is used to specify or read a specific tax law And With Format (08:00:00)")]
        public TimeOnly? StartTime { get; set; }

        [SwaggerSchema("End Time attribute of TimeOnly type is used to specify or read a specific tax law And With Format (08:00:00)")]
        public TimeOnly? EndTime { get; set; }


        /// <summary>
        /// Gets the API endpoint path for retrieving a tax rule by its ID.
        /// This path is used to make requests to the server to fetch the tax rule details.
        /// </summary>
        public string Path => "api/TaxCalculate/TaxRule/SearchByInputValue";
    }
}

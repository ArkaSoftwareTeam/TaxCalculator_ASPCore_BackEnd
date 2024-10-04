using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById
{
    /// <summary>
    /// Represents a query for retrieving a city along with its associated tax rules by city ID.
    /// This query is used to request specific city details and the corresponding tax rules from the server.
    /// </summary>
    public class GetCityWithTaxRulesByIdQuery : IQuery<CityWithTaxRulesQri>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the city for which the tax rules are being requested.
        /// </summary>
        [SwaggerSchema("Unique identifier of the city to retrieve tax rules")]
        public long CityId { get; set; }



        /// <summary>
        /// Gets the API endpoint path for retrieving tax rules associated with a city by its ID.
        /// This path is used to make requests to the server to fetch the city details along with its tax rules.
        /// </summary>
        public string Path => "api/TaxCalculate/GetTaxRuleWithCityById";
    }
}

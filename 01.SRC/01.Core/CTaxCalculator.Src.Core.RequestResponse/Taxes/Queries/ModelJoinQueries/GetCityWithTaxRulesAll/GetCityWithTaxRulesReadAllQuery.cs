using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll
{
    /// <summary>
    /// Represents a query to retrieve all cities along with their associated tax rules.
    /// This class is used to send a request to the API to fetch a comprehensive list of cities
    /// and the tax rules that apply to each city.
    /// </summary>
    public class GetCityWithTaxRulesReadAllQuery : IQuery<List<CityWithAllTaxRulesQir>>, IWebRequest
    {
        /// <summary>
        /// Gets the API endpoint path for retrieving all cities with their tax rules.
        /// This path is used to make requests to the server to fetch the relevant data.
        /// </summary>
        public string Path => "api/TaxCalculate/GetAllTaxRulesWithCity";
    }
}

using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll
{
    /// <summary>
    /// Represents a city along with its associated tax rules.
    /// This class is used to retrieve detailed information about a city,
    /// including its name and a collection of applicable tax rules.
    /// </summary>
    public class CityWithAllTaxRulesQir
    {
        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        [SwaggerSchema("Name of the city")]
        public string CityName { get; set; } = string.Empty;



        /// <summary>
        /// Gets or sets the collection of tax rules associated with the city.
        /// </summary>
        [SwaggerSchema("Collection of tax rules applicable to the city")]
        public ICollection<TaxRuleQri> TaxRules { get; set; } = new List<TaxRuleQri>();
    }
}

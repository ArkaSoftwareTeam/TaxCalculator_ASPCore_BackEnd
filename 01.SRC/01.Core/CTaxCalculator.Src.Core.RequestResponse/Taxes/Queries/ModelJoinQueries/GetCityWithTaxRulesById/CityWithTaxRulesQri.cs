using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById
{
    /// <summary>
    /// Represents a city along with its associated tax rules.
    /// This class contains the name of the city and a collection of tax rules that apply to the city.
    /// </summary>
    public class CityWithTaxRulesQri
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

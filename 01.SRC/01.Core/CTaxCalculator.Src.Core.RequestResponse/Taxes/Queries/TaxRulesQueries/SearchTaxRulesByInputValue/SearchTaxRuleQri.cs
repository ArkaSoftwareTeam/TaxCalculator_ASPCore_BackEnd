using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.SearchTaxRulesByInputValue
{

    /// <summary>
    /// Represents a tax rule with its associated parameters.
    /// This class is used to define the rules that govern the tax calculations.
    /// </summary>
    public class SearchTaxRuleQri
    {
        /// <summary>
        /// Gets or sets the unique identifier for the tax rule.
        /// </summary>
        [SwaggerSchema("Unique identifier of the tax rule")]
        public long TaxRuleId { get; set; }

        /// <summary>
        /// Gets or sets the start time for the tax rule's effective period.
        /// </summary>
        [SwaggerSchema("Start time of the tax rule")]
        public TimeOnly StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time for the tax rule's effective period.
        /// </summary>
        [SwaggerSchema("End time of the tax rule")]
        public TimeOnly EndTime { get; set; }

        /// <summary>
        /// Gets or sets the tax amount defined by the tax rule.
        /// </summary>
        [SwaggerSchema("Amount of tax defined by the tax rule")]
        public decimal TaxAmount { get; set; }
    }
}

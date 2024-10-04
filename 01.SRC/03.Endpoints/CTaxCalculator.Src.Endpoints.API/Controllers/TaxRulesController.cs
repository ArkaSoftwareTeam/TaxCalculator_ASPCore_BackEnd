using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddTaxRulesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesAmountReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesPeriodDateTimeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveTaxRulesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.SearchTaxRulesByInputValue;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers
{
    [Route("api/TaxCalculate/[controller]")]
    public class TaxRulesController : BaseController
    {

        #region Add a new Tax Rule
        /// <summary>
        /// Adds a new tax rule, specifying the applicable time frame, tax amount, and the city for which this rule applies.
        /// </summary>
        /// <param name="taxRule">The details of the tax rule to be created.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add a new Tax Rule", Description = "Receives values related to the creation of a new tax rule, including the time frame and tax amount, and specifies the city for which this rule is applicable.")]
        [SwaggerResponse(200, "Tax Rule successfully added", typeof(AddTaxRule))]
        [SwaggerResponse(400, "Invalid tax rule details provided")]
        public async Task<IActionResult> AddTaxRule(AddTaxRule taxRule)
        {
            return await Create<AddTaxRule, object>(taxRule);
        }
        #endregion

        #region Get One Tax Rule By Id
        /// <summary>
        /// Retrieves a tax rule by its ID.
        /// </summary>
        /// <param name="taxRuleQuery">The query containing the tax rule ID.</param>
        /// <returns>An IActionResult containing the details of the requested tax rule.</returns>
        [HttpGet("GetById")]
        [SwaggerOperation(Summary = "Get One Tax Rule By Id", Description = "Receives an ID from the user and returns the corresponding tax rule object.")]
        [SwaggerResponse(200, "Tax rule details retrieved successfully")]
        [SwaggerResponse(404, "Tax rule not found")]
        public async Task<IActionResult> GetTaxRuleById(GetTaxRuleByIdQuery taxRuleQuery)
            => await Query<GetTaxRuleByIdQuery, TaxRuleQri>(taxRuleQuery);
        #endregion

        #region Search In TaxRules By Optional Input Value 
        /// <summary>
        /// Searches for tax rules based on optional input values.
        /// </summary>
        /// <param name="taxRulesQuery">The search criteria for tax rules.</param>
        /// <returns>An IActionResult containing a paginated list of tax rules that match the criteria.</returns>
        [HttpGet("Search")]
        [SwaggerOperation(Summary = "Search Tax Rules", Description = "Searches for tax rules based on optional input values, returning a paginated result.")]
        [SwaggerResponse(200, "Search completed successfully")]
        [SwaggerResponse(400, "Invalid search criteria")]
        public async Task<IActionResult> SearchTaxRulesQuery(SearchTaxRuleQuery taxRulesQuery)
            => await Query<SearchTaxRuleQuery, PagedData<SearchTaxRuleQri>>(taxRulesQuery);
        #endregion

        #region Update TaxRules Amount
        /// <summary>
        /// Updates the amount of an existing tax rule.
        /// </summary>
        /// <param name="command">The command containing the new tax amount and relevant rule details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdateTaxRuleAmountPrice")]
        [SwaggerOperation(Summary = "Update Tax Rule Amount", Description = "Updates the amount for an existing tax rule.")]
        [SwaggerResponse(200, "Tax rule amount updated successfully")]
        [SwaggerResponse(404, "Tax rule not found")]
        public async Task<IActionResult> UpdateTaxRuleAmount([FromBody] ChangeTaxRuleAmount command)
            => await Edit(command);
        #endregion

        #region Update TaxRules DateTime
        /// <summary>
        /// Updates the effective period of an existing tax rule.
        /// </summary>
        /// <param name="command">The command containing the new date-time period and rule details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdateTaxRulePeriodDateTime")]
        [SwaggerOperation(Summary = "Update Tax Rule Period DateTime", Description = "Updates the time period for an existing tax rule.")]
        [SwaggerResponse(200, "Tax rule period updated successfully")]
        [SwaggerResponse(404, "Tax rule not found")]
        public async Task<IActionResult> UpdateTaxRulePeriodDateTime([FromBody] ChangeTaxRulePeriodDateTime command)
            => await Edit(command);
        #endregion

        #region Delete TaxRules With ID
        /// <summary>
        /// Deletes a tax rule by its ID.
        /// </summary>
        /// <param name="command">The command containing the tax rule ID to be removed.</param>
        /// <returns>An IActionResult indicating the result of the deletion operation.</returns>
        [HttpDelete("DeleteById")]
        [SwaggerOperation(Summary = "Delete Tax Rule By ID", Description = "Removes a tax rule from the system using its unique identifier.")]
        [SwaggerResponse(200, "Tax rule deleted successfully")]
        [SwaggerResponse(404, "Tax rule not found")]
        public async Task<IActionResult> RemoveTaxRule([FromBody] RemoveTaxRule command)
            => await Delete(command);
        #endregion

        #region Clear GC Methods
        /// <summary>
        /// Clears unused memory and triggers garbage collection.
        /// </summary>
        /// <returns>Boolean value indicating whether the operation was successful.</returns>
        [HttpGet("Clear")]
        [SwaggerOperation(Summary = "Clear memory", Description = "Triggers garbage collection to clear unused memory.")]
        [SwaggerResponse(200, "Memory cleared successfully")]
        public bool Clear()
        {
            GC.Collect(2);
            return true;
        }
        #endregion

    }
}

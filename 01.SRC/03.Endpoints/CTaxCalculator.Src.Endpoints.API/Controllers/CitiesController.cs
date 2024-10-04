using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddCitiesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeCityNameReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesByAllReferencesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesReQ;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers
{

    [Route("api/TaxCalculate/[controller]")]
    public class CitiesController : BaseController
    {
        #region Add City
        /// <summary>
        /// Adds a new city to the database.
        /// </summary>
        /// <param name="city">Details of the city to add.</param>
        /// <returns>Result of the operation.</returns>
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add a new city", Description = "Adds a new city to the database with the provided details.")]
        [SwaggerResponse(200, "City added successfully")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddCity(AddCity city)
        {
            return await Create<AddCity, object>(city);
        }
        #endregion

        #region Get City By Id (Read By Id)
        /// <summary>
        /// Retrieves city details by its ID.
        /// </summary>
        /// <param name="cityQuery">Query containing the city ID.</param>
        /// <returns>City details.</returns>
        [HttpGet("GetById")]
        [SwaggerOperation(Summary = "Get city by ID", Description = "Fetches the details of a city based on the provided city ID.")]
        [SwaggerResponse(200, "City found")]
        [SwaggerResponse(404, "City not found")]
        public async Task<IActionResult> GetCitiesById(GetCityByIdQuery cityQuery)
            => await Query<GetCityByIdQuery, CityQri>(cityQuery);

        #endregion

        #region Get One City With TaxRules References (City Join To TaxRule) => Join With Id 

        /// <summary>
        /// Retrieves city details with associated tax rules by city ID.
        /// </summary>
        /// <param name="cityQuery">Query containing the city ID.</param>
        /// <returns>City details with tax rules.</returns>
        [HttpGet("GetCityWithTaxRulesById")]
        [SwaggerOperation(Summary = "Get city with tax rules by ID", Description = "Fetches city details along with the associated tax rules based on the city ID.")]
        [SwaggerResponse(200, "City and tax rules found")]
        [SwaggerResponse(404, "City or tax rules not found")]
        public async Task<IActionResult> GetCityWithTaxRulesById(GetCityWithTaxRulesByIdQuery cityQuery)
            => await Query<GetCityWithTaxRulesByIdQuery, CityWithTaxRulesQri>(cityQuery);

        #endregion

        #region Get All City With With TaxRules (City Join To TaxtRoles) 
        /// <summary>
        /// Retrieves a list of all cities along with their tax rules.
        /// </summary>
        /// <param name="cityQuery">Query to retrieve all cities with tax rules.</param>
        /// <returns>List of cities with tax rules.</returns>
        [HttpGet("GetCityWithTaxRules")]
        [SwaggerOperation(Summary = "Get all cities with tax rules", Description = "Fetches a list of all cities along with their associated tax rules.")]
        [SwaggerResponse(200, "Cities and tax rules found")]
        public async Task<IActionResult> GetCityWithAllTaxRules(GetCityWithTaxRulesReadAllQuery cityQuery)
            => await Query<GetCityWithTaxRulesReadAllQuery, List<CityWithAllTaxRulesQir>>(cityQuery);

        #endregion

        #region Shearch City With Pagenations And Personal Properties Settings

        /// <summary>
        /// Searches for cities based on a given input value.
        /// </summary>
        /// <param name="cityQuery">Search query containing the input value.</param>
        /// <returns>Paged list of cities matching the search criteria.</returns>
        [HttpGet("SearchCities")]
        [SwaggerOperation(Summary = "Search for cities", Description = "Searches for cities based on a specific input value (name, code, etc.).")]
        [SwaggerResponse(200, "Cities found")]
        [SwaggerResponse(404, "No cities found matching the criteria")]
        public async Task<IActionResult> SearchCityByInputValue(SearchCityQuery cityQuery)
            => await Query<SearchCityQuery, PagedData<SearchCityQri>>(cityQuery);
        #endregion

        #region Update City Name
        /// <summary>
        /// Updates the name of an existing city.
        /// </summary>
        /// <param name="command">Command containing the city ID and the new name.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut("UpdateCityName")]
        [SwaggerOperation(Summary = "Update city name", Description = "Updates the name of a city based on the provided ID and new name.")]
        [SwaggerResponse(200, "City name updated successfully")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "City not found")]
        public async Task<IActionResult> CityNameChanged([FromBody] UpdateCityName command)
            => await Edit(command);
        #endregion

        #region Delete City With ID
        /// <summary>
        /// Deletes a city by its ID.
        /// </summary>
        /// <param name="command">Command containing the ID of the city to be deleted.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("Delete")]
        [SwaggerOperation(Summary = "Delete city by ID", Description = "Deletes a city from the database using its ID.")]
        [SwaggerResponse(200, "City deleted successfully")]
        [SwaggerResponse(404, "City not found")]
        public async Task<IActionResult> DeleteBlog([FromBody] RemoveCity command)
            => await Delete(command);
        #endregion

        #region Delete City And All References By Id
        /// <summary>
        /// Deletes a city and all its references by city ID.
        /// </summary>
        /// <param name="command">Command containing the city ID for deletion along with its references.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("DeleteGraph")]
        [SwaggerOperation(Summary = "Delete city and all references", Description = "Deletes a city along with all related references (e.g., tax rules) by city ID.")]
        [SwaggerResponse(200, "City and its references deleted successfully")]
        [SwaggerResponse(404, "City or references not found")]
        public async Task<IActionResult> DeleteGraphBlog([FromBody] RemoveCityWithReferences command)
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

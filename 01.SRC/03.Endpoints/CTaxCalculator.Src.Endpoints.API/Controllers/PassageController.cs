using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddPassagesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangePassagesDateTimeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTheCarIsCommutesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemovePassagesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.SearchPassagesByInputValue;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers
{
    [Route("api/TaxCalculator/[controller]")]
    public class PassageController : BaseController
    {

        #region Add Free Tax DateTime For Not Pay Tax Price
        /// <summary>
        /// Adds a new passage record for vehicles that are exempt from tax charges.
        /// </summary>
        /// <param name="passage">The details of the passage to be added.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add passage", Description = "Records a new passage for a vehicle that is exempt from tax charges.")]
        [SwaggerResponse(200, "Passage added successfully")]
        [SwaggerResponse(400, "Invalid passage details provided")]
        public async Task<IActionResult> AddPassage(AddPassage passage)
        {
            return await Create<AddPassage, object>(passage);
        }
        #endregion

        #region Get Passage By Id
        /// <summary>
        /// Retrieves a passage record by its ID.
        /// </summary>
        /// <param name="passageQuery">The query containing the passage ID.</param>
        /// <returns>An IActionResult containing the passage details.</returns>
        [HttpGet("GetById")]
        [SwaggerOperation(Summary = "Get passage by ID", Description = "Fetches the details of a specific passage using its unique identifier.")]
        [SwaggerResponse(200, "Passage details retrieved successfully")]
        [SwaggerResponse(404, "Passage not found")]
        public async Task<IActionResult> GetPassageById(GetPassageByIdQuery passageQuery)
            => await Query<GetPassageByIdQuery, PassageQri>(passageQuery);
        #endregion

        #region Search In Passage By Optional Input Value 
        /// <summary>
        /// Searches for passages based on optional date-time criteria.
        /// </summary>
        /// <param name="passageQuery">The search criteria for passages.</param>
        /// <returns>An IActionResult containing a paginated list of passages that match the criteria.</returns>
        [HttpGet("Search")]
        [SwaggerOperation(Summary = "Search passages", Description = "Searches for vehicle passages based on optional date-time criteria, returning a paginated result.")]
        [SwaggerResponse(200, "Search completed successfully")]
        [SwaggerResponse(400, "Invalid search criteria")]
        public async Task<IActionResult> SearchFreeTaxDatesByDateTime(SearchPassageQuery passageQuery)
            => await Query<SearchPassageQuery, PagedData<SearchPassageQri>>(passageQuery);
        #endregion

        #region Update FreeTax DateTime
        /// <summary>
        /// Updates the date-time of an existing passage record.
        /// </summary>
        /// <param name="command">The command containing the new date-time and passage details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdatePassageDateTime")]
        [SwaggerOperation(Summary = "Update passage date-time", Description = "Updates the date-time of an existing vehicle passage record.")]
        [SwaggerResponse(200, "Passage date-time updated successfully")]
        [SwaggerResponse(404, "Passage not found")]
        public async Task<IActionResult> UpdatePassageDateTime([FromBody] ChangePassageDateTime command)
            => await Edit(command);
        #endregion

        #region Update Car In This Passage
        /// <summary>
        /// Updates the Vehicle of an existing passage record.
        /// </summary>
        /// <param name="command">The command containing the new Vehicle and passage details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdateTheVehicleIsThisPassage")]
        [SwaggerOperation(Summary = "Update The Vehicle Is This Passage", Description = "Updates the Vehicle of passage record.")]
        [SwaggerResponse(200, "Passage Vehicle updated successfully")]
        [SwaggerResponse(404, "Passage not found")]
        public async Task<IActionResult> ChangeTheVehicleIsCommute([FromBody] ChangeTheCarIsCommute command)
            => await Edit(command);
        #endregion

        #region Delete FreeTax DateTime With ID
        /// <summary>
        /// Deletes a passage record by its ID.
        /// </summary>
        /// <param name="command">The command containing the passage ID to be removed.</param>
        /// <returns>An IActionResult indicating the result of the deletion operation.</returns>
        [HttpDelete("RemovePassageById")]
        [SwaggerOperation(Summary = "Delete passage by ID", Description = "Removes a passage record from the system using its unique identifier.")]
        [SwaggerResponse(200, "Passage deleted successfully")]
        [SwaggerResponse(404, "Passage not found")]
        public async Task<IActionResult> RemovePassage([FromBody] RemovePassage command)
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

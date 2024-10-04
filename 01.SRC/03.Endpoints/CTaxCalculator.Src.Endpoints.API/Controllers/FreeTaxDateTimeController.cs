using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddFreeTaxDateTimeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeFreeTaxDateTimeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveFreeTaxDateTimeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers
{
    [Route("api/TaxCalculator/[controller]")]
    public class FreeTaxDateTimeController : BaseController
    {
        #region Add Free Tax DateTime For Not Pay Tax Price
        /// <summary>
        /// Adds a new free tax date for a city.
        /// </summary>
        /// <param name="freeTaxDateTime">Details of the free tax date to be added.</param>
        /// <returns>Result of the add operation.</returns>
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add free tax date for a city", Description = "Adds a new free tax date during which no tax will be charged for a city.")]
        [SwaggerResponse(200, "Free tax date added successfully")]
        [SwaggerResponse(400, "Invalid input data")]
        public async Task<IActionResult> AddFreeTaxDateTimeForCity(AddFreeTaxDateTime freeTaxDateTime)
            => await Create<AddFreeTaxDateTime, object>(freeTaxDateTime);
        #endregion

        #region Get FreeTax DateTime By Id
        /// <summary>
        /// Retrieves a free tax date by its ID.
        /// </summary>
        /// <param name="freeTaxDateQuery">Query containing the ID of the free tax date.</param>
        /// <returns>Details of the free tax date.</returns>
        [HttpGet("GetById")]
        [SwaggerOperation(Summary = "Get free tax date by ID", Description = "Fetches details of a specific free tax date using its ID.")]
        [SwaggerResponse(200, "Free tax date retrieved successfully")]
        [SwaggerResponse(404, "Free tax date not found")]
        public async Task<IActionResult> GetFreeTaxDateById(GetFreeTaxDateByIdQuery freeTaxDateQuery)
            => await Query<GetFreeTaxDateByIdQuery, FreeTaxDateQri>(freeTaxDateQuery);
        #endregion

        #region Get All FreeTax DateTime
        /// <summary>
        /// Retrieves all free tax dates.
        /// </summary>
        /// <param name="freeTaxDateQuery">Optional filters for retrieving all free tax dates.</param>
        /// <returns>List of all free tax dates.</returns>
        [HttpGet("ReadAll")]
        [SwaggerOperation(Summary = "Get all free tax dates", Description = "Fetches all free tax dates in the system.")]
        [SwaggerResponse(200, "List of free tax dates retrieved successfully")]
        public async Task<IActionResult> GetAllFreeTaxDates(GetFreeTaxDatesReadAllQuery freeTaxDateQuery)
            => await Query<GetFreeTaxDatesReadAllQuery, List<FreeTaxDatesQri>>(freeTaxDateQuery);
        #endregion

        #region Search In FreeTax DateTime By Optional Input Value 
        /// <summary>
        /// Searches free tax dates based on optional date input.
        /// </summary>
        /// <param name="freeTaxDateQuery">Query containing search criteria (optional).</param>
        /// <returns>Paged data of free tax dates matching the criteria.</returns>
        [HttpGet("SearchWithDateTime")]
        [SwaggerOperation(Summary = "Search free tax dates", Description = "Searches free tax dates based on an optional input value such as date or other criteria.")]
        [SwaggerResponse(200, "Search results retrieved successfully")]
        public async Task<IActionResult> SearchFreeTaxDatesByDateTime(SearchFreeTaxDatesQuery freeTaxDateQuery)
            => await Query<SearchFreeTaxDatesQuery, PagedData<FreeTaxDatesSearchQri>>(freeTaxDateQuery);
        #endregion

        #region Update FreeTax DateTime
        /// <summary>
        /// Updates an existing free tax date for a city.
        /// </summary>
        /// <param name="command">Command containing the updated details of the free tax date.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut("FreeTaxDateTimeUpdate")]
        [SwaggerOperation(Summary = "Update free tax date", Description = "Updates the details of an existing free tax date for a city.")]
        [SwaggerResponse(200, "Free tax date updated successfully")]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Free tax date not found")]
        public async Task<IActionResult> FreeTaxDateTimeChanged([FromBody] ChangeFreeTaxDatetime command)
            => await Edit(command);
        #endregion

        #region Delete FreeTax DateTime With ID
        /// <summary>
        /// Deletes a free tax date by its ID.
        /// </summary>
        /// <param name="command">Command containing the ID of the free tax date to be deleted.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("Delete")]
        [SwaggerOperation(Summary = "Delete free tax date by ID", Description = "Deletes a free tax date using its ID.")]
        [SwaggerResponse(200, "Free tax date deleted successfully")]
        [SwaggerResponse(404, "Free tax date not found")]
        public async Task<IActionResult> DeleteFreeTaxDateTime([FromBody] RemoveFreeTaxDateTime command)
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

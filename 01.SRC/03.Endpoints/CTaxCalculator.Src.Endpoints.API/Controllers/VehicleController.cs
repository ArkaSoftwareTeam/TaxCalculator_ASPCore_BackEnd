using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddVehiclesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesPlateNumberReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesTypeReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveVehiclesReQ;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers
{
    [Route("api/TaxCalculator/[controller]")]
    public class VehicleController : BaseController
    {
        #region Add a new Vehicle
        /// <summary>
        /// Adds a new vehicle to the system for tax calculation purposes.
        /// </summary>
        /// <param name="vehicle">The details of the vehicle to be added.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add a new vehicle", Description = "Adds a new vehicle to the system to be considered for tax calculations.")]
        [SwaggerResponse(200, "Vehicle added successfully")]
        [SwaggerResponse(400, "Invalid vehicle details provided")]
        public async Task<IActionResult> AddVehicle(AddVehicle vehicle)
        {
            return await Create<AddVehicle, string>(vehicle);
        }
        #endregion

        #region Get One Vehicle By Id
        /// <summary>
        /// Retrieves a vehicle's details by its ID.
        /// </summary>
        /// <param name="vehicleQuery">The query containing the vehicle ID.</param>
        /// <returns>An IActionResult containing the vehicle details.</returns>
        [HttpGet("GetById")]
        [SwaggerOperation(Summary = "Get vehicle by ID", Description = "Fetches the details of a specific vehicle using its unique identifier.")]
        [SwaggerResponse(200, "Vehicle details retrieved successfully")]
        [SwaggerResponse(404, "Vehicle not found")]
        public async Task<IActionResult> GetVehicleById(GetVehicleByIdQuery vehicleQuery)
           => await Query<GetVehicleByIdQuery, VehicleResQri>(vehicleQuery);
        #endregion

        #region Search In Vehicle By Optional Input Value 
        /// <summary>
        /// Searches for vehicles based on optional input values.
        /// </summary>
        /// <param name="vehiclesQuery">The search criteria for vehicles.</param>
        /// <returns>An IActionResult containing a paginated list of vehicles that match the criteria.</returns>
        [HttpGet("SearchBy")]
        [SwaggerOperation(Summary = "Search vehicles", Description = "Searches for vehicles based on optional input values, returning a paginated result.")]
        [SwaggerResponse(200, "Search completed successfully")]
        [SwaggerResponse(400, "Invalid search criteria")]
        public async Task<IActionResult> SearchVehicleByInputValue(SearchVehiclesQuery vehiclesQuery)
            => await Query<SearchVehiclesQuery, PagedData<SearchVehiclesResQri>>(vehiclesQuery);
        #endregion

        #region Update Vehicle PlateNumber
        /// <summary>
        /// Updates the plate number of an existing vehicle.
        /// </summary>
        /// <param name="command">The command containing the new plate number and vehicle details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdateVehiclePlateNumber")]
        [SwaggerOperation(Summary = "Update vehicle plate number", Description = "Updates the plate number of an existing vehicle in the system.")]
        [SwaggerResponse(200, "Vehicle plate number updated successfully")]
        [SwaggerResponse(404, "Vehicle not found")]
        public async Task<IActionResult> ChangeVehiclePlateNumber([FromBody] ChangeVehiclePlateNumber command)
            => await Edit(command);
        #endregion

        #region Update Vehicle Type
        /// <summary>
        /// Updates the type of an existing vehicle.
        /// </summary>
        /// <param name="command">The command containing the new vehicle type and details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("UpdateVehicleType")]
        [SwaggerOperation(Summary = "Update vehicle type", Description = "Updates the type of an existing vehicle in the system.")]
        [SwaggerResponse(200, "Vehicle type updated successfully")]
        [SwaggerResponse(404, "Vehicle not found")]
        public async Task<IActionResult> ChangeVehicleType([FromBody] ChangeVehicleType command)
            => await Edit(command);
        #endregion

        #region Delete TaxRules With ID
        /// <summary>
        /// Deletes a vehicle from the system by its ID.
        /// </summary>
        /// <param name="command">The command containing the vehicle ID to be removed.</param>
        /// <returns>An IActionResult indicating the result of the deletion operation.</returns>
        [HttpDelete("DeleteById")]
        [SwaggerOperation(Summary = "Delete vehicle by ID", Description = "Removes a vehicle from the system using its unique identifier.")]
        [SwaggerResponse(200, "Vehicle deleted successfully")]
        [SwaggerResponse(404, "Vehicle not found")]
        public async Task<IActionResult> RemoveVehicle([FromBody] RemoveVehicle command)
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

using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById
{
    /// <summary>
    /// Represents the response model for vehicle details.
    /// This class contains information about a vehicle, including its ID, type, plate number, city, and total tax amount.
    /// </summary>
    public class VehicleResQri
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        [SwaggerSchema("Unique identifier for the vehicle.")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the type of the vehicle (e.g., car, motorcycle, truck).
        /// </summary>
        [SwaggerSchema("Type of the vehicle (e.g., car, motorcycle, truck).")]
        public string VehicleType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the plate number of the vehicle.
        /// </summary>
        [SwaggerSchema("Plate number of the vehicle.PlateNumber Format => { LKI256 }")]
        public string PlateNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city where the vehicle is registered.
        /// </summary>
        [SwaggerSchema("City where the vehicle is registered.")]
        public string City { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the Last Tax Passage Amount associated with the vehicle.
        /// </summary>
        [SwaggerSchema("Last Tax Passage Amount associated with the vehicle.")]
        public decimal LastTaxPassageAmount { get; set; }



        /// <summary>
        /// Gets or sets the total tax amount associated with the vehicle.
        /// </summary>
        [SwaggerSchema("Total tax amount associated with the vehicle.")]
        public decimal TotalTaxAmount { get; set; }
    }
}

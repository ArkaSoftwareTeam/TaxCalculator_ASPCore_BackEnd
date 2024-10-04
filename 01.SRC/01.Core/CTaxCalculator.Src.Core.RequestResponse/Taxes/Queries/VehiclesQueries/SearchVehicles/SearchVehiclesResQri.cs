using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles
{
    /// <summary>
    /// Represents the result of a vehicle search, containing details about each vehicle.
    /// </summary>
    public class SearchVehiclesResQri
    {
        /// <summary>
        /// Unique identifier for the vehicle.
        /// </summary>
        [SwaggerSchema("Unique identifier for the vehicle.")]
        public long VehicleId { get; set; }


        /// <summary>
        /// Type of the vehicle, e.g., Car, Truck, etc.
        /// </summary>
        [SwaggerSchema("Type of the vehicle, e.g., Car, Truck, etc.")]
        public string VehicleType { get; set; } = string.Empty;


        /// <summary>
        /// License plate number of the vehicle.
        /// </summary>
        [SwaggerSchema("License plate number of the vehicle.")]
        public string PlateNumber { get; set; } = string.Empty;


        /// <summary>
        /// City where the vehicle is registered.
        /// </summary>
        [SwaggerSchema("City where the vehicle is registered.")]
        public string City { get; set; } = string.Empty;


        /// <summary>
        /// Total tax amount applicable for the vehicle.
        /// </summary>
        [SwaggerSchema("Total tax amount applicable for the vehicle.")]
        public decimal TotalTaxAmount { get; set; }
    }
}

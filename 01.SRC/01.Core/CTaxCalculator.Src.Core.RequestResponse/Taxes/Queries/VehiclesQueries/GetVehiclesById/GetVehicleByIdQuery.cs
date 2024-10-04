using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById
{
    /// <summary>
    /// Represents a query to retrieve a vehicle by its unique identifier.
    /// This class implements the <see cref="IQuery{T}"/> interface for handling vehicle retrieval requests.
    /// </summary>
    public class GetVehicleByIdQuery : IQuery<VehicleResQri>, IWebRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the vehicle to be retrieved.
        /// </summary>
        [SwaggerSchema("Unique identifier of the vehicle to retrieve")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Gets the path for the API endpoint to call for retrieving the vehicle.
        /// </summary>
        public string Path => "api/TaxCalculator/Vehicle/GetById";
    }
}

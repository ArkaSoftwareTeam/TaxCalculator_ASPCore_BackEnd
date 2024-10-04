using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById
{
    /// <summary>
    /// Represents a city with its unique identifier and name.
    /// This class is used for the final representation of city data in the application.
    /// </summary>
    public class CityQri
    {
        /// <summary>
        /// Gets or sets the unique identifier of the city.
        /// This ID is used to uniquely identify a city in the system.
        /// </summary>
        [SwaggerSchema("Unique identifier of the city")]
        public long Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the city.
        /// This property holds the name by which the city is known.
        /// </summary>

        [SwaggerSchema("Name of the city")]
        public string CityName { get; set; } = string.Empty;
    }
}

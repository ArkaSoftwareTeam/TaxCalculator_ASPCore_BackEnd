using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById
{
    /// <summary>
    /// Represents a Passage with its unique identifier and name.
    /// This class is used for the final representation of Passage data in the application.
    /// </summary>
    public class PassageQri
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Passage.
        /// This ID is used to uniquely identify a Passage in the system.
        /// </summary>
        [SwaggerSchema("Unique identifier of the Passage")]
        public long Id { get; set; }


        /// <summary>
        /// Gets or sets the DateTime of the Passage.
        /// This property holds the DateTime by which the Passage is known.
        /// </summary>

        [SwaggerSchema("DateTime Of Passage")]
        public DateTime PassageDateTime { get; set; }
    }
}

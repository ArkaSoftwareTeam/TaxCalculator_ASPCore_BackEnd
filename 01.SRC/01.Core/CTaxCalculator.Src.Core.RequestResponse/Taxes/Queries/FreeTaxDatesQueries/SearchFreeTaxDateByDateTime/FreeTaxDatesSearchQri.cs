using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime
{

    /// <summary>
    /// Represents a query response for searching free tax dates, including the identifier, date, and time.
    /// This class is used to transfer data related to searched free tax dates in the API responses.
    /// </summary>
    public class FreeTaxDatesSearchQri
    {
        /// <summary>
        /// Gets or sets the unique identifier of the free tax date.
        /// </summary>
        [SwaggerSchema("Unique identifier of the free tax date")]
        public long FreeTaxDateId { get; set; }


        /// <summary>
        /// Gets or sets the date of the free tax period.
        /// </summary>
        [SwaggerSchema("Date of the free tax period")]
        public DateTime Date { get; set; }


        /// <summary>
        /// Gets or sets the time of the free tax period.
        /// </summary>
        [SwaggerSchema("Time of the free tax period")]
        public DateTime Time { get; set; }
    }
}

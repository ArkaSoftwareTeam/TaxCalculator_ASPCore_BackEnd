using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll
{

    /// <summary>
    /// Represents a query response object for free tax dates.
    /// This class is used to hold the details of a free tax date
    /// that can be retrieved via the API.
    /// </summary>
    /// <remarks>
    /// The <see cref="FreeTaxDatesQri"/> class serves as a Data Transfer Object (DTO)
    /// that encapsulates the essential properties related to a free tax date.
    /// It includes the unique identifier, the date, and the time associated with the tax rule.
    /// </remarks>
    public class FreeTaxDatesQri
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

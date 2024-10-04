using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById
{
    /// <summary>
    /// Represents a free tax date with its unique identifier, date, and time details.
    /// This class is used for the final representation of free tax date data in the application.
    /// </summary>
    /// <remarks>
    /// The <see cref="FreeTaxDateQri"/> class is used in the context of tax calculations and 
    /// exemptions within the application. It provides the necessary details to identify 
    /// and utilize a specific free tax date. The properties are mapped directly to the 
    /// API response for retrieving free tax date information.
    /// </remarks>
    public class FreeTaxDateQri
    {
        /// <summary>
        /// Gets or sets the unique identifier for the free tax date.
        /// This ID is used to uniquely identify a specific free tax date in the system.
        /// </summary>
        [SwaggerSchema("Unique identifier of the free tax date")]
        public long FreeTaxDateId { get; set; }



        /// <summary>
        /// Gets or sets the date of the free tax period.
        /// This property holds the specific date on which the tax exemption applies.
        /// </summary>
        [SwaggerSchema("Date of the free tax exemption")]
        public DateTime Date { get; set; }



        /// <summary>
        /// Gets or sets the time associated with the free tax date.
        /// This property indicates the specific time for which the tax exemption is valid.
        /// </summary>
        [SwaggerSchema("Time associated with the free tax exemption")]
        public DateTime Time { get; set; }

    }
}

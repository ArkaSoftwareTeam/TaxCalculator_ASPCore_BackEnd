using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Framework.Core.RequestResponse.Queries
{
    /// <summary>
    /// Represents the base structure for returning paginated data when querying.
    /// This class encapsulates the results of a query, including pagination information.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data returned from the query.</typeparam>
    public class PagedData<T>
    {
        /// <summary>
        /// Gets or sets the list of query results.
        /// </summary>
        [SwaggerSchema("The list of results returned from the query.")]
        public List<T>? QueryResult { get; set; }


        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        [SwaggerSchema("The current page number of the results.")]
        public int PageNumber { get; set; } = 1;


        /// <summary>
        /// Gets or sets the size of each page, which determines how many results are returned per page.
        /// </summary>
        [SwaggerSchema("The number of items per page.")]
        public int PageSize { get; set; } = 10;


        /// <summary>
        /// Gets or sets the total number of items available across all pages.
        /// </summary>
        [SwaggerSchema("The total number of items available for the query.")]
        public int TotalCount { get; set; }
    }
}

using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Framework.Core.RequestResponse.Queries
{

    /// <summary>
    /// Base class used as a marker for classes that define input parameters for search queries.
    /// This interface is utilized when the search requires pagination.
    /// </summary>
    /// <typeparam name="TData">The type of data to be returned from the query.</typeparam>
    public class PageQuery<TData> : IPageQuery<TData>
    {
        /// <summary>
        /// Gets or sets the page number from which data should be loaded.
        /// </summary>
        [SwaggerSchema("The page number from which data should be loaded.")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of records per page.
        /// </summary>
        [SwaggerSchema("The number of records on each page.")]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets the number of records to skip to reach the desired records.
        /// </summary>
        [SwaggerSchema("The number of records to skip to reach the desired records.")]
        public int SkipCount => (PageNumber - 1) * PageSize;

        /// <summary>
        /// Gets or sets a value indicating whether to return the total count of records available in the search.
        /// </summary>
        [SwaggerSchema("Indicates whether the total count of records available in the search should be returned.")]
        public bool NeedTotalCount { get; set; }

        /// <summary>
        /// Gets or sets the column by which sorting is performed.
        /// </summary>
        [SwaggerSchema("The column by which sorting is performed.")]
        public string SortBy { get; set; } = "Id";

        /// <summary>
        /// Gets or sets a value indicating whether data should be sorted in ascending order or descending order.
        /// </summary>
        [SwaggerSchema("Indicates whether the data is sorted in ascending or descending order.")]
        public bool SortAscending { get; set; }
    }



    /// <summary>
    /// Base record used as a marker for records that define input parameters for search queries.
    /// This interface is utilized when the search requires pagination.
    /// </summary>
    /// <typeparam name="TData">The type of data to be returned from the query.</typeparam>
    public record PageQueryRecord<TData> : IPageQuery<TData>
    {
        /// <summary>
        /// Gets or sets the page number from which data should be loaded.
        /// </summary>
        [SwaggerSchema("The page number from which data should be loaded.")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of records per page.
        /// </summary>
        [SwaggerSchema("The number of records on each page.")]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets the number of records to skip to reach the desired records.
        /// </summary>
        [SwaggerSchema("The number of records to skip to reach the desired records.")]
        public int SkipCount => (PageNumber - 1) * PageSize;

        /// <summary>
        /// Gets or sets a value indicating whether to return the total count of records available in the search.
        /// </summary>
        [SwaggerSchema("Indicates whether the total count of records available in the search should be returned.")]
        public bool NeedTotalCount { get; set; }

        /// <summary>
        /// Gets or sets the column by which sorting is performed.
        /// </summary>
        [SwaggerSchema("The column by which sorting is performed.")]
        public string SortBy { get; set; } = "Id";

        /// <summary>
        /// Gets or sets a value indicating whether data should be sorted in ascending order or descending order.
        /// </summary>
        [SwaggerSchema("Indicates whether the data is sorted in ascending or descending order.")]
        public bool SortAscending { get; set; }
    }
}

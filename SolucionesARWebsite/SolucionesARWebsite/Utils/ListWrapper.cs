using System;
using System.Collections;

namespace SolucionesARWebsite.Utils
{
    /// <summary>
    /// Holds sorting and pagination data.
    /// </summary>
    public abstract class ListWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWrapper"/> class.
        /// </summary>
        protected ListWrapper()
        {
            CurrentPage = 0;
            TotalPages = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListWrapper"/> class.
        /// </summary>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="filters">The filters.</param>
        protected ListWrapper(object sortField, SortDirectionType sortDirection, IDictionary filters)
        {
            SortField = sortField;
            SortDirection = sortDirection;
            Filters = filters;
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the totalitems.
        /// </summary>
        /// <value>The totalitems.</value>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        public object SortField { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList Items { get; set; }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>The filters.</value>
        public IDictionary Filters { get; set; }

        /// <summary>
        /// Gets or sets the current sorting direction.
        /// </summary>
        public SortDirectionType SortDirection { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is asc.
        /// </summary>
        /// <value><c>true</c> if this instance is asc; otherwise, <c>false</c>.</value>
        public bool IsDescending
        {
            get
            {
                return SortDirection == SortDirectionType.Descending;
            }
        }

        /// <summary>
        /// Updates the total amount of pages according to the given parameters.
        /// </summary>
        /// <param name="count">Total count of items in the database</param>
        /// <param name="pageSize">Number of items to display per page</param>
        /// <param name="page">Requested page, if greater than TotalPages, is set to TotalPages</param>
        public void CalculatePagination(int count, int pageSize, int page)
        {
            TotalItems = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            if (TotalPages == 0)
            {
                TotalPages = 1;
            }
            if (page < 1)
            {
                page = 1;
            }
            if (page > TotalPages)
            {
                page = TotalPages;
            }
            CurrentPage = page;
        }

        /// <summary>
        /// Determines whether this instance has filters.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance has filters; otherwise, <c>false</c>.
        /// </returns>
        public bool HasFilters()
        {
            return Filters != null && Filters.Count > 0;
        }
    }
}
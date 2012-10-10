using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum StoreListSortField
    {
        [Value("store_id")]
        Id,
        [Value("created_at")]
        CreatedAt,
    }

    public enum StoreListFilter
    {
        [Value("store_id")]
        Id,
    }

    #endregion

    public class StoresList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Store> Items
        {
            get
            {
                return (List<Store>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        /// <value></value>
        public new StoreListSortField SortField
        {
            get
            {
                return (StoreListSortField)base.SortField;
            }
            set
            {
                base.SortField = value;
            }
        }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>The filters.</value>
        public new Dictionary<StoreListFilter, string> Filters
        {
            get
            {
                return (Dictionary<StoreListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public StoresList()
        {
        }

        public StoresList(CompanyListSortField sort, SortDirectionType dir, Dictionary<CompanyListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
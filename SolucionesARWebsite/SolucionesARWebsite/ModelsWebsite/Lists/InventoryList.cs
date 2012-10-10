using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum InventoryListSortField
    {
        [Value("inventory_id")]
        Id,
        [Value("name")]
        Name,
        [Value("username")]
        Username,
        [Value("created_at")]
        CreatedAt,
    }

    public enum InventoryListFilter
    {
        [Value("inventory_id")]
        Id,
        [Value("name")]
        Name,
        [Value("username")]
        Username,
    }

    #endregion

    public class InventoryList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<List<Transaction>> Items
        {
            get
            {
                return (List<List<Transaction>>)base.Items;
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
        public new InventoryListSortField SortField
        {
            get
            {
                return (InventoryListSortField)base.SortField;
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
        public new Dictionary<InventoryListFilter, string> Filters
        {
            get
            {
                return (Dictionary<InventoryListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public InventoryList()
        {
        }

        public InventoryList(InventoryListSortField sort, SortDirectionType dir, Dictionary<InventoryListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
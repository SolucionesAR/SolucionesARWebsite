using System.Collections.Generic;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.ViewModels.Lists
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

    public class InventoryList : BaseListModel
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

        #endregion

        #region Constructors

        public InventoryList()
        {
        }

        public InventoryList(InventoryListSortField sort, SortDirectionType dir, Dictionary<InventoryListFilter, string> filters)
        {
        }

        #endregion
    }
}
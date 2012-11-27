using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ViewModels.Lists
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

    public class StoresList : BaseListModel
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
        
        #endregion

        #region Constructors

        public StoresList()
        {
        }
        
        #endregion
    }
}
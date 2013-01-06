using System.Collections.Generic;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.ViewModels.Lists
{
    #region enums

    public enum ProvinceListSortField
    {
        [Value("id")]
        Id,
        [Value("name")]
        Name,
    }

    public enum ProvinceListFilter
    {
        [Value("provinceId")]
        Id,
        [Value("name")]
        Name,
    }
    #endregion

    public class ProvincesList : BaseListModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Province> Items
        {
            get
            {
                return (List<Province>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }
        
        #endregion

        #region Constructors

        public ProvincesList()
        {
        }

        public ProvincesList(ProvinceListSortField sort, SortDirectionType dir, Dictionary<ProvinceListFilter, string> filters)
        {
        }

        #endregion
    }
}
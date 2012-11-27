using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ViewModels.Lists
{
    #region enums

    public enum CantonListSortField
    {
        [Value("id")]
        Id,
        [Value("name")]
        Name,
        [Value("provinceId")]
        ProvinceId,
    }

    public enum CantonListFilter
    {
        [Value("cantonId")]
        Id,
        [Value("name")]
        Name,
        [Value("provinceId")]
        ProvinceId,
    }
    #endregion
    public class CantonsList : BaseListModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Canton> Items
        {
            get
            {
                return (List<Canton>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }

        #endregion

        #region Constructors

        public CantonsList()
        {
        }

        public CantonsList(CantonListSortField sort, SortDirectionType dir, Dictionary<CantonListFilter, string> filters)
        {
        }

        #endregion
    }
}
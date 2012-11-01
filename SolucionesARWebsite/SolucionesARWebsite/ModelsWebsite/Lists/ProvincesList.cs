using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
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
        [Value("companyId")]
        Id,
        [Value("name")]
        Name,
    }
    #endregion

    public class ProvincesList : ListWrapper
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

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        /// <value></value>
        public new ProvinceListSortField SortField
        {
            get
            {
                return (ProvinceListSortField)base.SortField;
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
        public new Dictionary<ProvinceListFilter, string> Filters
        {
            get
            {
                return (Dictionary<ProvinceListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public ProvincesList()
        {
        }

        public ProvincesList(ProvinceListSortField sort, SortDirectionType dir, Dictionary<ProvinceListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
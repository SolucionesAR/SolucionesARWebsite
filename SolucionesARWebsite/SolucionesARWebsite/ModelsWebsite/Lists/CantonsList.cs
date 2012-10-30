using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
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
    public class CantonsList : ListWrapper
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

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        /// <value></value>
        public new CantonListSortField SortField
        {
            get
            {
                return (CantonListSortField)base.SortField;
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
        public new Dictionary<CantonListFilter, string> Filters
        {
            get
            {
                return (Dictionary<CantonListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public CantonsList()
        {
        }

        public CantonsList(CantonListSortField sort, SortDirectionType dir, Dictionary<CantonListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
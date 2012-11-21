using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum RolListSortField
    {
        [Value("rol_id")]
        Id,
        [Value("created_at")]
        CreatedAt,
    }

    public enum RolListFilter
    {
        [Value("rol_id")]
        Id,
    }

    #endregion

    public class RolesList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Rol> Items
        {
            get
            {
                return (List<Rol>)base.Items;
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
        public new RolListSortField SortField
        {
            get
            {
                return (RolListSortField)base.SortField;
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
        public new Dictionary<RolListFilter, string> Filters
        {
            get
            {
                return (Dictionary<RolListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public RolesList()
        {
        }

        public RolesList(CompanyListSortField sort, SortDirectionType dir, Dictionary<CompanyListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
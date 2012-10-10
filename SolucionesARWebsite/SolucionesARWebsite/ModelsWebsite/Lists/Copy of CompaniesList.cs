using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum CompanyListSortField
    {
        [Value("id")]
        Id,
        [Value("name")]
        Name,
        [Value("enabled")]
        Enabled,
        [Value("created_at")]
        CreatedAt,
        [Value("updated_at")]
        UpdatedAt,
    }

    public enum CompanyListFilter
    {
        [Value("companyId")]
        Id,
        [Value("name")]
        Name,
        [Value("enabled")]
        Enabled,
    }
    #endregion

    public class CompaniesList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Company> Items
        {
            get
            {
                return (List<Company>)base.Items;
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
        public new CompanyListSortField SortField
        {
            get
            {
                return (CompanyListSortField)base.SortField;
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
        public new Dictionary<CompanyListFilter, string> Filters
        {
            get
            {
                return (Dictionary<CompanyListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public CompaniesList()
        {
        }

        public CompaniesList(CompanyListSortField sort, SortDirectionType dir, Dictionary<CompanyListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
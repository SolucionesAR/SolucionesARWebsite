using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
{
    #region enums

    public enum UsersListSortField
    {
        [Value("user_id")]
        Id,
        [Value("name")]
        Name,
        [Value("email")]
        Email,
        [Value("username")]
        Sellname,
        [Value("role")]
        Role,
        [Value("enabled")]
        Enabled,
        [Value("created_at")]
        CreatedAt,
    }

    public enum UsersListFilter
    {
        [Value("user_id")]
        Id,
        [Value("name")]
        Name,
        [Value("username")]
        Username,
        [Value("email")]
        Email,
        [Value("role")]
        Role,
        [Value("enabled")]
        Enabled,
    }

    #endregion

    public class UsersList : ListWrapper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<User> Items
        {
            get
            {
                return (List<User>)base.Items;
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
        public new UsersListSortField SortField
        {
            get
            {
                return (UsersListSortField)base.SortField;
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
        public new Dictionary<UsersListFilter, string> Filters
        {
            get
            {
                return (Dictionary<UsersListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public UsersList()
        {
        }

        public UsersList(UsersListSortField sort, SortDirectionType dir, Dictionary<UsersListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}
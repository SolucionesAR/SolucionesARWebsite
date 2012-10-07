using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Views.Users
{
    #region enums
    public enum UserListSortField
    {
        [Value("id")]
        Id,
        [Value("name")]
        Name,
        [Value("email")]
        Email,
        [Value("username")]
        Username,
        [Value("role")]
        Role,
        [Value("enabled")]
        Enabled,
        [Value("created_at")]
        CreatedAt,
        [Value("updated_at")]
        UpdatedAt,
    }

    public enum UserListFilter
    {
        [Value("userId")]
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
        public new UserListSortField SortField
        {
            get
            {
                return (UserListSortField)base.SortField;
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
        public new Dictionary<UserListFilter, string> Filters
        {
            get
            {
                return (Dictionary<UserListFilter, string>)base.Filters;
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

        public UsersList(UserListSortField sort, SortDirectionType dir, Dictionary<UserListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }
        #endregion
    }
}
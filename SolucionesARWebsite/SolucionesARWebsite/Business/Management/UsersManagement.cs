using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class UsersManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly UsersAccess _usersAccess;

        #endregion

        #region Constructors

        public UsersManagement()
        {
            _usersAccess = new UsersAccess();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersList()
        {
            return _usersAccess.GetUsersList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return _usersAccess.GetUser(userId);
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
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
        public List<User> GetUsers()
        {
            return _usersAccess.GetUsers();
        }

        #endregion
        
        #region Private Methods
        #endregion
    }
}
using System.Collections.Generic;
using SolucionesARWebsite.Business.Logic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;
using SolucionesARWebsite.Utils;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User GetUser(string username)
        {
            return _usersAccess.GetUser(username);
        }

        public virtual UserInformation GetUserInformation(string username)
        {
            var user = _usersAccess.GetUser(username);
            user = new User
                       {
                           UserId = 10,
                           RolId = (int) UserRole.SuperUser,
                           FName = "Cesar",
                           LName1 = "BArboza",
                           LName2 = "Gonzalez"

                       };
            var userRole = (UserRole) user.RolId;
            var roleName = userRole.ToStringValue();
            var userInformation = new UserInformation
                           {
                               Id = user.UserId,
                               Name = string.Format("{0} {1} {2}", user.FName, user.LName1, user.LName2),
                               Username = username,
                               Role = roleName,
                               RoleId = user.RolId,
                           };

            return userInformation;
        }
        
        public void Save(EditFormModel editFormModel, int updatedBy)
        {
            var user = new FormMapper().Map(editFormModel);

            if (editFormModel.UserId == 0)
            {
                AddUser(user);
            }
            EditUser(user);
        }
        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            _usersAccess.AddUser(user);
        }

        private void EditUser(User user)
        {
            _usersAccess.EditUser(user);
        }

        #endregion    
    }
}
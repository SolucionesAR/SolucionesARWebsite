using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.Business.Management
{
    public class UsersManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IUsersRepository _usersRepository;

        #endregion

        #region Constructors

        public UsersManagement(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        #endregion

        #region Public Methods

        public List<User> GetOrderedUsersList()
        {
            return _usersRepository.GetOrderedUsersList();
        }

        public List<User> GetUsersList()
        {
            return _usersRepository.GetUsersList();
        }

        public User GetUser(int userId)
        {
            return _usersRepository.GetUserById(userId);
        }

        public User GetUserByIdentificationNumber(int identificationNumber)
        {
            return _usersRepository.GetUserByIdentificationNumber(identificationNumber);
        }

        public User GetUserByGeneratedCode(string username)
        {
            return _usersRepository.GetUserByGeneratedCode(username);
        }

        public virtual UserInformation GetUserInformation(string identificationNumber)
        {
            var user = _usersRepository.GetUserByIdentificationNumber(Convert.ToInt32(identificationNumber));
            var userRole = (UserRoles)user.RolId;
            var roleName = userRole.ToStringValue();
            var userInformation = new UserInformation
                           {
                               Id = user.UserId,
                               Name = string.Format("{0} {1} {2}", user.FName, user.LName1, user.LName2),
                               Username = identificationNumber,
                               Role = roleName,
                               RoleId = user.RolId,
                           };

            return userInformation;
        }

        public void Save(User user, int updatedBy)
        {
            if (user.UserId == 0)
            {
                AddUser(user);
            }
            else
            {
                EditUser(user);
            }
        }

        public void SavePayment(int userId, double cashback, int updatedBy)
        {
            _usersRepository.SavePayment(userId, cashback, updatedBy);
        }

        public bool HasValidIdentificationNumber(int userId, string identificationNumber)
        {
            return _usersRepository.HasValidIdentificationNumber(userId, Convert.ToInt32(identificationNumber.Replace("-", string.Empty)));
        }

        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            user.CreatetedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.GeneratedCode,
                                                           BCrypt.Net.BCrypt.GenerateSalt((int) Constants.WorkFactor));
            _usersRepository.AddUser(user);
        }

        private void EditUser(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            _usersRepository.EditUser(user);
        }

        public void Delete(int userId)
        {
            _usersRepository.Delete(userId);
        }

        #endregion
    }
}
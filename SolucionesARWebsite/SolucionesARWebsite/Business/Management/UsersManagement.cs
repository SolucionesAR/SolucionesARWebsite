using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;
using SolucionesARWebsite.ViewModels.Users;

namespace SolucionesARWebsite.Business.Management
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

        public User GetUser(string username)
        {
            return _usersRepository.GetUserByGeneratedCode(username);
        }

        public virtual UserInformation GetUserInformation(string username)
        {
            var user = _usersRepository.GetUserByGeneratedCode(username);
            var userRole = (UserRoles)user.RolId;
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

        public void Save(EditViewModel editViewModel, int updatedBy)
        {
            var user = Map(editViewModel);
            if (editViewModel.UserId == 0)
            {
                AddUser(user);
            }
            else
            {
                EditUser(user);
            }
        }

        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            user.CreatetedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            _usersRepository.AddUser(user);
        }

        private void EditUser(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            _usersRepository.EditUser(user);
        }
        
        private User Map(EditViewModel editViewMode)
        {
            var user = new User
                           {
                               Address1 = editViewMode.Address1,
                               Address2 = editViewMode.Address2,
                               Cashback = Convert.ToDouble(editViewMode.Cashback),
                               CedNumber = Convert.ToInt32(editViewMode.IdentificationNumber),
                               Cellphone = editViewMode.Cellphone,
                               CompanyId = editViewMode.Company.CompanyId,
                               DistrictId = editViewMode.DistrictId,
                               Dob = editViewMode.Dob,
                               Email = editViewMode.Email,
                               Enabled = editViewMode.Enabled,
                               FName = editViewMode.FirstName,
                               GeneratedCode = editViewMode.GeneratedCode,
                               LName1 = editViewMode.LastName1,
                               LName2 = editViewMode.LastName2,
                               Nationality = editViewMode.Nationality,
                               IdentificationTypeId = editViewMode.IdentificationType.IdentificationTypeId,
                               RolId = editViewMode.UserRol.RolId,
                               //tenemos que eliminar los guiones
                               PhoneNumber = editViewMode.PhoneNumber,
                               RelationshipTypeId = editViewMode.RelationshipType.RelationshipTypeId,
                               UserId = editViewMode.UserId,
                               UserReferenceId = editViewMode.UserId,
                           };

            if (!string.IsNullOrEmpty(editViewMode.UserReference))
            {
                var parentUser = _usersRepository.GetUserByGeneratedCode(editViewMode.UserReference);
                user.UserReferenceId = parentUser != null ? parentUser.UserId : 0;
            }
            return user;
        }

        #endregion    
    }
}
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

        public List<User> GetUsersList()
        {
            return _usersRepository.GetUsersList();
        }

        public User GetUser(int userId)
        {
            return _usersRepository.GetUser(userId);
        }

        public User GetUser(string username)
        {
            return _usersRepository.GetUserByCode(username);
        }

        public virtual UserInformation GetUserInformation(string username)
        {
            //var user = _usersRepository.GetUserByCode(username);
            var user = new User
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

        public void Save(EditViewModel editViewModel, int updatedBy)
        {
            var user = Map(editViewModel);
            if (editViewModel.UserId == 0)
            {
                AddUser(user);
            }
            EditUser(user);
        }
        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            user.CreatetedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            user.Dob = DateTime.UtcNow;
            _usersRepository.AddUser(user);
        }

        private void EditUser(User user)
        {
            user.UpdatedAt = DateTime.Now;
            _usersRepository.EditUser(user);
        }

        private User Map(EditViewModel editViewMode)
        {
            var user = new User
                           {
                               Address1 = editViewMode.Address1,
                               Address2 = editViewMode.Address2,
                               IdentificationTypeId = editViewMode.IdentificationType.IdentificationTypeId,
                               CompanyId = editViewMode.Company.CompanyId,
                               Dob = editViewMode.Dob,
                               Email = editViewMode.Email,
                               Enabled = editViewMode.Enabled,
                               FName = editViewMode.FirstName,
                               LName1 = editViewMode.LastName1,
                               LName2 = editViewMode.LastName2,
                               GeneratedCode = editViewMode.GeneratedCode,
                               Nationality = editViewMode.Nationality,
                               RolId = editViewMode.UserRol.RolId,
                               UserId = editViewMode.UserId,
                               //tenemos que eliminar los guiones
                               CedNumber = Convert.ToInt32(editViewMode.IdentificationNumber),
                               Cellphone = editViewMode.Cellphone,
                               PhoneNumber = editViewMode.PhoneNumber,
                               DistrictId = editViewMode.District.DistrictId,
                           };

            if (!string.IsNullOrEmpty(editViewMode.ParentUser))
            {
                var parentUser = _usersRepository.GetUserByCode(editViewMode.ParentUser);
                user.UserReferenceId = parentUser.UserId;
            }

            return user;
        }

        #endregion    
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public UsersRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void AddUser(User user)
        {
            _databaseModel.Users.Add(user);
            _databaseModel.SaveChanges();
        }

        public void EditUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public List<User> GetOrderedUsersList()
        {
            var users = _databaseModel.Users.OrderBy(u => u.CedNumber).ToList();
            return users;
        }
        
        public List<User> GetUsersList()
        {
            var users = _databaseModel.Users.Where(u => u.Enabled).ToList();
            return users;
        }

        public User GetUserById(int userId)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(userId));
            return user;
        }

        public User GetUserByGeneratedCode(string username)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.GeneratedCode.Equals(username));
            return user;
        }

        public User GetUserByIdentificationNumber(int identificationNumber)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.CedNumber.Equals(identificationNumber));
            return user;
        }

        public User GetSolucionesArUser()
        {
            var user = GetUserById((int) Constants.SolucionesArUser);
            return user;
        }

        public bool UpdateUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
            return true;
        }

        public bool HasValidIdentificationNumber(int userId, int identificationNumber)
        {
            // validate if the current user has the same identification number saved in the data base
            var currentUser = _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(userId));
            if(currentUser != null && currentUser.CedNumber.Equals(identificationNumber))
            {
                return true;
            }

            // validate the new identification number is not in the data base
            return _databaseModel.Users.FirstOrDefault(u => u.CedNumber.Equals(identificationNumber)) != null;
        }

        public void Delete(int userId)
        {
            var user = GetUserById(userId);
            user.Enabled = false;
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();

        }

        #endregion

        #region Private Methods
        #endregion
    }
}
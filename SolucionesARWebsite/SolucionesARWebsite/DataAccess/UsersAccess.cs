using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class UsersAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public UsersAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersList()
        {
            var users = _databaseModel.Users.ToList();
            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(userId));
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User GetUser(string username)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.GeneratedCode.Equals(username));
            return user;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public bool UpdateUser(User user)
        {
            //TODO: por implementar: con solo salvar la bd con el user actualizado? o hay q sacarlo, cambiar todo y guardar??
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
            return true;
        }

        public void EditUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public void AddUser(User user)
        {
            _databaseModel.Users.Add(user);
            _databaseModel.SaveChanges();
        }

        #endregion

        #region Private Methods
        #endregion

    }
}
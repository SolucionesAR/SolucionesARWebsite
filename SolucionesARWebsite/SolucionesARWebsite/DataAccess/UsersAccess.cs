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
        public List<User> GetUsers()
        {
            var users = _databaseModel.Users.ToList();
            return users;
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
        #endregion

        #region Private Methods
        #endregion

        
    }
}
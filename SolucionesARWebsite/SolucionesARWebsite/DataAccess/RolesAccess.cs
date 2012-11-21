using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class RolesAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public RolesAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void EditRol(Rol rol)
        {
            var rolEntity = _databaseModel.Roles.FirstOrDefault(r => r.RolId.Equals(rol.RolId));
            if (rolEntity!= null)
            {
                rolEntity.Name = rol.Name;
            }
            _databaseModel.SaveChanges();
        }

        public void AddRol(Rol rol)
        {
            _databaseModel.Roles.Add(rol);
            _databaseModel.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rol> GetRoles()
        {
            var rolesList = _databaseModel.Roles.ToList();
            return rolesList;
        }

        public Rol GetRol(int rolId)
        {
            var rol = _databaseModel.Roles.FirstOrDefault(r => r.RolId.Equals(rolId));
            return rol;
        }

        public void Delete(int rolId)
        {
            //TODO: Create and set a disable property
            var rolEntity = _databaseModel.Roles.FirstOrDefault(r => r.RolId.Equals(rolId));
            _databaseModel.Roles.Remove(rolEntity);
            _databaseModel.SaveChanges();
        }

        #endregion
    }
}
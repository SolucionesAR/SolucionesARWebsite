using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public RolesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void AddRol(Rol rol)
        {
            _databaseModel.Roles.Add(rol);
            _databaseModel.SaveChanges();
        }

        public void EditRol(Rol rol)
        {
            _databaseModel.Entry(rol).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public List<Rol> GetAllRoles()
        {
            var roles = _databaseModel.Roles.ToList();
            return roles;
        }

        public List<Rol> GetRoles()
        {
            var roles = _databaseModel.Roles.ToList();
            return roles;
        }

        public Rol GetRol(int rolId)
        {
            var roles = _databaseModel.Roles.First(r => r.RolId.Equals(rolId));
            return roles;
        }

        public void AddRoles(List<Rol> rolesList)
        {
            DbModel _databaseModel = new DbModel();
            var i = 1;
            foreach (var rol in rolesList)
            {
                rol.RolId = i;
                rol.CreatedAt = DateTime.UtcNow;
                rol.UpdatedAt = DateTime.UtcNow;
                _databaseModel.Roles.Add(rol);
                i += 1;
                _databaseModel.SaveChanges();
            }
        }

        public void Add(List<IdentificationType> identificationTypesList)
        {
            DbModel _databaseModel = new DbModel();
            var i = 1;
            foreach (var rol in identificationTypesList)
            {
                rol.IdentificationTypeId = i;
                _databaseModel.IdentificationType.Add(rol);
                i += 1;
                _databaseModel.SaveChanges();
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
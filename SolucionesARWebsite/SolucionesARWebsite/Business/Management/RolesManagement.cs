using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Roles;

namespace SolucionesARWebsite.Business.Management
{
    public class RolesManagement
    {
        #region Private Members

        private readonly RolesAccess _rolesAccess;

        #endregion

        #region Constructors

        public RolesManagement()
        {
            _rolesAccess = new RolesAccess();
        }

        #endregion

        #region Public Methods

        public List<Rol> GetRoles()
        {
            return _rolesAccess.GetRoles();
        }

        public Rol GetRol(int rolId)
        {
            return _rolesAccess.GetRol(rolId);
        }

        public void Save(EditFormModel editFormModel)
        {
            var rol = new Rol
                           {
                               RolId = editFormModel.RolId,
                               Name = editFormModel.RolName,
                           };
            if (editFormModel.RolId == 0)
            {
                AddUser(rol);
            }
            EditUser(rol);
        }

        public void Delete(int rolId)
        {
            _rolesAccess.Delete(rolId);
        }

        #endregion

        #region Private Methods

        private void AddUser(Rol rol)
        {
            rol.CreatedAt = DateTime.UtcNow;
            rol.UpdatedAt = DateTime.UtcNow;
            _rolesAccess.AddRol(rol);
        }

        private void EditUser(Rol rol)
        {
            rol.UpdatedAt = DateTime.UtcNow;
            _rolesAccess.EditRol(rol);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class RolesAccess
    {
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
    }
}
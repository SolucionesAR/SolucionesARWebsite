using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class RolesManagement
    {
        public void Save(List<Rol> rolesList)
        {
        var _rolesAccess = new RolesAccess();

        _rolesAccess.AddRoles(rolesList);
        }

        public void Save(List<IdentificationType> identificationTypesList)
        {
            var _rolesAccess = new RolesAccess();

            _rolesAccess.Add(identificationTypesList);
        }
    }
}
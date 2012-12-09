using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IRolesRepository
    {
        void AddRol(Rol rol);

        void EditRol(Rol rol);

        List<Rol> GetAllRoles();

        List<Rol> GetRoles();

        Rol GetRol(int rolId);
    }
}

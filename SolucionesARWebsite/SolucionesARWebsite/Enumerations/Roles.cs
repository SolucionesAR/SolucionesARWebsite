using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.Enumerations
{
    #region Enums
    
    #endregion
    
    public static class Roles
    {
        #region Static Methods

        public static string GetRoleDescription(UserRoles role)
        {
            switch (role)
            {
                case UserRoles.Customer:
                    return "Vendedor";
                case UserRoles.Salesman:
                    return "Dependiente";
                case UserRoles.Manager:
                    return "Gerente";
                case UserRoles.SuperUser:
                    return "Super User";
                case UserRoles.Administrator:
                    return "Administrador";
                default:
                    return role.ToStringValue();
            }
        }

        #endregion
    }
}

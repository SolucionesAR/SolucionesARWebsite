using System;
using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.Enumerations
{
    #region Enums

    public enum UserRole
    {
        [Value("customer")]
        Customer = 1,
        [Value("salesman")]
        Salesman = 2,
        [Value("manager")]
        Manager = 5,
        [Value("administrator")]
        Administrator = 10,
        [Value("super_user")]
        SuperUser = 11,
    }

    #endregion
    
    public static class Roles
    {
        #region Static Methods

        public static string GetRoleDescription(UserRole role)
        {
            switch (role)
            {
                case UserRole.Customer:
                    return "Cliente";
                case UserRole.Salesman:
                    return "Vendedor";
                case UserRole.Manager:
                    return "Gerente";
                case UserRole.SuperUser:
                    return "Super User";
                case UserRole.Administrator:
                    return "Administrador";
                default:
                    return role.ToStringValue();
            }
        }

        #endregion
    }

    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}

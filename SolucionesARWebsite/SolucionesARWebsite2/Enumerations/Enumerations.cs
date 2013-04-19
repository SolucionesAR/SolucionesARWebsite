using System;
using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.Enumerations
{
    #region Enums

    public enum Controllers
    {
        [Value("Account")] Account,
    }

    public enum AccountActions
    {
        [Value("Login")] Login,
        [Value("LogOff")] LogOff,
    }

    public enum IdentificationTypes
    {
        [Value("Cédula")]
        CedNumber = 1,
        [Value("Cédula de Residencia")]
        ResidenceCedNumber = 2,
        [Value("Pasaporte")]
        Passport = 3,
        [Value("Otro")]
        Other = 4,
    }

    public enum UserRoles
    {
        [Value("customer")]
        Customer = 2,
        [Value("salesman")]
        Salesman = 3,
        [Value("manager")]
        Manager = 4,
        [Value("administrator")]
        Administrator = 5,
        [Value("super_user")]
        SuperUser = 6,
    }

    public enum RelationshipTypes
    {
        [Value("Novato")]
        Amateur = 1,
        [Value("Junior")]
        Junior = 2,
        [Value("Senior")]
        Senior = 3,
        [Value("Master")]
        Master = 4,
    }

    public enum Constants
    {
        [Value("DefaultProvince")]
        DefaultProvince = 1,
        [Value("DefaultCanton")]
        DefaultCanton = 1,
        [Value("DefaultDistricts")]
        DefaultDistrict = 1,
        [Value("UsuarioSolucionesAr")]
        SolucionesArUser,
        [Value("UsuarioSolucionesArCreator")]
        SolucionesArUserCreator,
        [Value("$@R|SOLuc10n3s")]
        SolucionesArPassword,
        [Value("RoleBasedMenu")]
        RoleBasedMenu = 6,
        WorkFactor = 13,
    }

    public enum ApplicationReports
    {
        [Value("Ventas para SolucionesAR")]
        SolucionesAr = 1,
        [Value("Ventas por Compañia")]
        Company = 2,
        [Value("Ventas por Vendedor")]
        Customer = 3,
        [Value("Comportamiento de la Aplicación")]
        Application = 4,
    }

    #endregion

    public static class Enumerations
    {
        #region Public Methods

        public static string GetDescription(IdentificationTypes idType)
        {
            return idType.ToStringValue();
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

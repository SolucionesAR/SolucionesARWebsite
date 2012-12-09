using System;
using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.Enumerations
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

    public enum Constants
    {
        [Value("UsuarioSolucionesAr")]
        SolucionesArUser = 22
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

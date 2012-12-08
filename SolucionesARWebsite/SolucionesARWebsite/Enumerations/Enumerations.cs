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

    public enum Constants
    {
        SolucionesArId = 1
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
}

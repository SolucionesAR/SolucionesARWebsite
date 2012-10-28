using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Views.Account
{
    public class LoginViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        [Display(Name = "Nombre de Usuario", Prompt = "username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña", Prompt = "password")]
        public string Password { get; set; }

        #endregion

        #region Private Members
        #endregion

        #region Contructors
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}

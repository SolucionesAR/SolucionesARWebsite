using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Views.Account
{
    public class LoginViewModel
    {
        #region Constants
        #endregion

        #region Properties

        [Display(Name = "Nombre de Usuario", Prompt = "username")]
        [Required(ErrorMessage = "Nombre de usuario es requerido")]
        public string Username { get; set; }

        [Display(Name = "Contraseña", Prompt = "password")]
        [Required(ErrorMessage = "Contraseña es requerida")]
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

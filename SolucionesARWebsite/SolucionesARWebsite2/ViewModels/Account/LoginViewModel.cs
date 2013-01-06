using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        [Display(Name = "Nombre de Usuario", Prompt = "username")]
        [Required(ErrorMessage = "Nombre de usuario es requerido")]
        public string Username { get; set; }

        [Display(Name = "Contraseña", Prompt = "password")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        public string Password { get; set; }

        #endregion
        
        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}

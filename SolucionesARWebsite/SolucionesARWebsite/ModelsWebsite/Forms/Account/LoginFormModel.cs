
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Account
{
    public class LoginFormModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required(ErrorMessage = "Nombre de usuario es requerido")]
        public string Username { get; set; }

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

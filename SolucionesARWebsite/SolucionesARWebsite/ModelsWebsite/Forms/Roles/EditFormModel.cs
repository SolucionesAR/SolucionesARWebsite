using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Roles
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique Rol identifier
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// The Rol name
        /// </summary>
        [Required]
        public string RolName { get; set; }

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
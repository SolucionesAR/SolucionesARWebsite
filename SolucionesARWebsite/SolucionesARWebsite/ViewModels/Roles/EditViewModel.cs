using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ViewModels.Roles
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        [Required]
        public int RolId { get; set; }

        /// <summary>
        /// The Company Name
        /// </summary>
        [Required]
        [Display(Name = "Nombre*", Prompt = "Nombre")]
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
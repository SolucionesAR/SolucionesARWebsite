using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Roles
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required]
        public int RolId { get; set; }

        [Display(Name = "Nombre*", Prompt = "Nombre")]
        [Required(ErrorMessage = "Nombre es requerido")]
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
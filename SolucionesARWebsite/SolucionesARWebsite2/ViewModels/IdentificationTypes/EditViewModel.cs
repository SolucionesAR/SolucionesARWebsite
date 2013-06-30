using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.IdentificationTypes
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        public int IdentificationTypeId { get; set; }

        [Display(Name = "Descripcion*", Prompt = "Descripcion")]
        [Required(ErrorMessage = "Descripcion es requerida")]
        public string Description { get; set; }
        
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
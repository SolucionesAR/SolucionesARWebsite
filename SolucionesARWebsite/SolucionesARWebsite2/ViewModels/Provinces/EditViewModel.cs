using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Provinces
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        public int ProvinceId { get; set; }

        [Display(Name = "Nombre*", Prompt = "Nombre")]
        [Required(ErrorMessage = "Nombre de provincia es requerido")]
        public string ProvinceName { get; set; }

        
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
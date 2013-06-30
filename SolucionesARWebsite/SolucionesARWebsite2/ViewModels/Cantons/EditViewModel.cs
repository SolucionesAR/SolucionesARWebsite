using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Cantons
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required]
        public int CantonId { get; set; }

        [Display(Name = "Provincia*")]
        [Required(ErrorMessage = "Provincia es requerida")]
        public int ProvinceId { get; set; }

        [Display(Name = "Nombre*", Prompt = "Nombre")]
        [Required(ErrorMessage = "Nombre del canton es requerido")]
        public string CantonName { get; set; }
        
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
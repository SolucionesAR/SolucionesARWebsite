using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ViewModels.Cantons
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required]
        public int CantonId { get; set; }

        [Required]
        [Display(Name = "Id de la Provincia*")]
        public int ProvinceId { get; set; }

        [Required]
        [Display(Name = "Nombre*", Prompt = "Nombre")]
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
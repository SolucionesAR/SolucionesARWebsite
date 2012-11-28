using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ViewModels.Districts
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The district id
        /// </summary>
        [Required]
        public int DistrictId { get; set; }

        /// <summary>
        /// The district name
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string DistrictName { get; set; }

        /// <summary>
        /// The canton id
        /// </summary>
        [Required]
        [Display(Name = "Id del Canton*", Prompt = "Canton")]
        public int CantonId { get; set; }
        
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
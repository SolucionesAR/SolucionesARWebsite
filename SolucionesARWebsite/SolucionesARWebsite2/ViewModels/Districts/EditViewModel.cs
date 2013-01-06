using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Districts
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
        [Display(Name = "Provincia*", Prompt = "Provincia")]
        public int ProvinceId { get; set; }
        /// <summary>
        /// The canton id
        /// </summary>
        [Required]
        [Display(Name = "Canton*", Prompt = "Canton")]
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
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Views.Districts
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string DistrictName { get; set; }

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
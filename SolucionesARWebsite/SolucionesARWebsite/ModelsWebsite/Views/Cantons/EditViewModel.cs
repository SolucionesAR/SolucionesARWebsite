using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Views.Cantons
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        public int CantonId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string CantonName { get; set; }

        public int ProvinceId { get; set; }

        
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
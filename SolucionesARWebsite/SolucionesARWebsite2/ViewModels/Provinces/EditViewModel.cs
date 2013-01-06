using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Provinces
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
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
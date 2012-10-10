using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Companies
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// The Company Name
        /// </summary>
        [Required]
        public string CompanyName { get; set; }

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        [Required]
        public string CorporateId { get; set; }

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        [Required]
        public double CashBackPercentaje { get; set; }

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
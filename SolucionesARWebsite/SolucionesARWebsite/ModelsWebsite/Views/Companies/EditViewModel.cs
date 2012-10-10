using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Views.Companies
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        [Display(Name = "Cédula Juríca*", Prompt = "123456789")]
        public string CorporateId { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        [Required]
        [Display(Name = "Porcentage Cashback*", Prompt = "10.0")]
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
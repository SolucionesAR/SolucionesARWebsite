using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Companies
{
    public class EditViewModel : BaseViewModel
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
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        [Required(ErrorMessage = "Nombre de la compañia es requerido")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        [Display(Name = "Cédula Jurídica", Prompt = "3-101-123456")]
        public string CorporateId { get; set; }

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        [Display(Name = "Porcentaje Cashback*", Prompt = "10.0")]
        [Required(ErrorMessage = "Porcentaje Cashback es requerido")]
        public string CashBackPercentage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Nickname", Prompt = "Nickname")]
        public string CompanyNickname{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Habilitada*")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Financiera?*")]
        public bool IsFinantial { get; set; }

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
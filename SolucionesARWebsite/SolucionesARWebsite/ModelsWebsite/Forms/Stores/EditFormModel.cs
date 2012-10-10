using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Stores
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique store identifier
        /// </summary>
        [Required]
        public int StoreId { get; set; }

        /// <summary>
        /// The store name
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        public string State { get; set; }

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
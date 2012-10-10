using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Inventory
{
    public class UploadFormModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Company Id
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
        
        /// <summary>
        /// The User Id
        /// </summary>
        [Required]
        public int UserId { get; set; }
        
        /// <summary>
        /// The File with transactions
        /// </summary>
        [Required]
        public string FileRoute { get; set; }
        
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
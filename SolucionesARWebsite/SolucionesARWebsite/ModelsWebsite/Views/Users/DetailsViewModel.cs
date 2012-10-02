using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ModelsWebsite.Views.Users
{
    public class DetailsViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public int CedNumber { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        public string LName1 { get; set; }

        /// <summary>
        /// The second Last Name
        /// </summary>
        public string LName2 { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        public string GeneratedCode { get; set; }
        
        /// <summary>
        /// To check if the user is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The total amount of users cash back 
        /// </summary>
        public double Cashback { get; set; }

        /// <summary>
        /// The rol id
        /// </summary>
        public Rol Rol { get; set; }

        /// <summary>
        /// The last N transactions
        /// </summary>
        public List<string> LastTransactions { get; set; }

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
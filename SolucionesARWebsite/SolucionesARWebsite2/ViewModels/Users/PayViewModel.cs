using System.ComponentModel;

namespace SolucionesARWebsite2.ViewModels.Users
{
    public class PayViewModel : BaseViewModel
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
        public int IdentificationNumber { get; set; }

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
        /// The total amount of users cash back with colones format 
        /// </summary>
        public double LastCashback { get; set; }

        /// <summary>
        /// The total amount of users cash back with colones format 
        /// </summary>
        [DisplayName("Monto a Debitar")]
        public double Cashback { get; set; }

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
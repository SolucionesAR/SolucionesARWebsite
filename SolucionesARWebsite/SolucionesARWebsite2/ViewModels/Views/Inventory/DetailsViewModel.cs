using System.Collections.Generic;
using System.ComponentModel;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Views.Inventory
{
    public class DetailsViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Quantity of affacted users
        /// </summary>
        [DisplayName("Cantidad de Usuarios")]
        public int QtyAffectedUsers { get; set; }

        /// <summary>
        /// The total amount of mone reported
        /// </summary>
        public string MoneyReported { get; set; }

        /// <summary>
        /// The Transactions List
        /// </summary>
        public List<Transaction> TransactionsList { get; set; }

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
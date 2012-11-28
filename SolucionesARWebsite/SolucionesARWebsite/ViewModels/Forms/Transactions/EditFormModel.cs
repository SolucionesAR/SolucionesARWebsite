using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Forms.Transactions
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BillBarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Store Store { get; set; }


        /// <summary>
        /// The one who sales in the store
        /// </summary>
        // [Required]
        // [DisplayName("Dependiente")]
        // public User SalesMan { get; set; }

        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [Required]
        public User Customer { get; set; }

        public List<User> ListCustomers { get; set; }

        // public List<User> ListSalesMan { get; set; }

        public List<Store> ListStores { get; set; }

        public int Points { get; set; }


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
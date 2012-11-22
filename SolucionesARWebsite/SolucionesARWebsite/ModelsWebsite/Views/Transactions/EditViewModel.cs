using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ModelsWebsite.Views.Transactions
{
    public class EditViewModel : BaseViewModel
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
        [Display(Name = "Codigo Fractura*", Prompt = "Codigo Fractura")]
        public string BillBarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Monto*", Prompt = "000.00")]
        public double Amount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("Tienda")]
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
        [DisplayName("Vendedor")]
        public User Customer { get; set; }

        public List<User> ListCustomers { get; set; }

       // public List<User> ListSalesMan { get; set; }

        public List<Store> ListStores { get; set; }


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
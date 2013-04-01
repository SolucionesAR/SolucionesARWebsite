using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Transactions
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
        [DisplayName("Compania")]
        public Company Company { get; set; }


        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [Required]
        [DisplayName("Vendedor")]
        public User Customer { get; set; }

        public List<User> CustomersList { get; set; }

        // public List<User> ListSalesMan { get; set; }

        public List<Company> CompaniesList { get; set; }

        [Display(Name = "Puntos*", Prompt = "50")]
        public int Points { get; set; }

        [Display(Name = "Fecha", Prompt = "01/01/1970")]
        public string TransactionDate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Comision*", Prompt = "000.00")]
        public double Comision { get; set; }
        
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
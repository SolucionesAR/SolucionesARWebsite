using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.CreditProcesses
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessId { get; set; }
        
        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [Required]
        [DisplayName("Cliente")]
        public Customer Customer { get; set; }

        public List<Customer> CustomersList { get; set; }

        [Required]
        [DisplayName("Vendedor")]
        public User Salesman { get; set; }

        public List<User> SalesmenList { get; set; }

        public List<Company> CompaniesList { get; set; }

        [Required]
        [DisplayName("Estado")]
        public CreditStatus CreditStatus { get; set; }
        public List<CreditStatus> CreditStatusesList { get; set; }

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
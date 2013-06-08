using PagedList;
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
        /// 
        /// </summary>
        [Required]
        [DisplayName("Producto del credito")]
        public string Product { get; set; }
        
        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [Required]
        [DisplayName("Cliente")]
        public Customer Customer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Customer> CustomersList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("Vendedor")]
        public User Salesman { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<User> SalesmenList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Company FinantialCompany { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Company> FinantialCompaniesList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("Estado")]
        public CreditStatus CreditStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CreditStatus> CreditStatusesList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IPagedList<CreditProcessXCompany> PagedItems { get; set; }

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
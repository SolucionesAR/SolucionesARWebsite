using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Lists;

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
        [DisplayName("Producto del credito")]
        [Required]
        public string Product { get; set; }
        
        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [DisplayName("Cliente")]
        [Required]
        public Customer Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserToShow> CustomersList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Vendedor")]
        [Required]
        public User Salesman { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserToShow> SalesmenList { get; set; }

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
        [DisplayName("Estado")]
        [Required]
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
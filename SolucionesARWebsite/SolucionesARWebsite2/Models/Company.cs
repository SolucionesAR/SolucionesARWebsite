using System;
using System.Collections.Generic;

namespace SolucionesARWebsite2.Models
{
    public class Company
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyNickName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double CashBackPercentaje { get; set; }

        /// <summary>
        /// Could be the "cedula juridica"
        /// </summary>
        public string CorporateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatetedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Store> Stores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }

        /// <summary>
        /// To check if the company is enabled
        /// </summary>
        public bool Enabled { get; set; }


        #endregion
    }

}
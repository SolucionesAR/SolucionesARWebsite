using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CreditProcessXCompany
    {
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessXCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CreditProcess CreditProcess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Company Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual CreditStatus CreditStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreditStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
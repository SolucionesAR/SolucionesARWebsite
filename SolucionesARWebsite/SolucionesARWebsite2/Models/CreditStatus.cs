using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CreditStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public int CreditStatusId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreditStatusDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CreditProcess> CreditProcesses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CreditProcessLog> CreditProcessLogs { get; set; }
    }
}
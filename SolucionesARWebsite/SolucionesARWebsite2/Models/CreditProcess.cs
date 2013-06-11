using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CreditProcess
    {
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
       
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
        public string Product { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CreditProcessLog> CreditProcessLogs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CreditComment> CreditComments { get; set; }

    }
}
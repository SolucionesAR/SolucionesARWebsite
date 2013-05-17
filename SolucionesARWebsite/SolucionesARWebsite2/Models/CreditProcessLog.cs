using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CreditProcessLog
    {
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessLogId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual CreditProcess CreditProcess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("LastStatusId")]
        public CreditStatus LastStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LastStatusId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("NewStatusId")]
        public CreditStatus NewStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NewStatusId { get; set; }
    }
}
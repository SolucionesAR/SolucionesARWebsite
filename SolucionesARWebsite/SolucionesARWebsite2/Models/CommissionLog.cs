using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CommissionLog
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int CommissionLogId { get; set; }

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
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatetedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }
        #endregion

    }
}
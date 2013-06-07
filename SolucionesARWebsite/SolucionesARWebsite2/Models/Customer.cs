using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CedNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Boss { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Possition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LaboralTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CreditProcess> CreditProcesses { get; set; }
    }
}
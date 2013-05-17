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
        public virtual Company Company { get; set; }
        //TODO: me gustaria q fuera aqui mismo toda la lista de financieras, como q de alguna forma solo creo un proceso 
        //de credito q asocio a varias financieras pero al final solo una avanza
        // Pero por facilidad y comodidad mejor manejar cada proceso por aparte
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
        public string ExtraDetails { get; set; }
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
        public virtual ICollection<CreditProcessLog> CreditProcessLogs { get; set; }

    }
}
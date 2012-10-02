using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite.Models
{
    public class Company
    {

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public double CashBackPercentaje { get; set; }

        /// <summary>
        /// Could be the "cedula juridica"
        /// </summary>
        public string CorporateId { get; set; }

        public DateTime CreatetedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }

}
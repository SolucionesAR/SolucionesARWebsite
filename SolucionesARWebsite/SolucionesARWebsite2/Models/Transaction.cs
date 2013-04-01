using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolucionesARWebsite2.Models
{
    public class Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BillBarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime TransactionDate { get; set; }

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
        //public int StoreId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public virtual Store Store { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        /// <summary>
        /// The one who sales in the store
        /// </summary>
        //public int SalesManId { get; set; }

        /// <summary>
        /// The one who sales in the store
        /// </summary>
        //[ForeignKey("SalesManId")]
        //public virtual User SalesMan { get; set; }


        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        [ForeignKey("CustomerId")]
        public virtual User Customer { get; set; }

        /// <summary>
        /// The amount of points earned for the transaction
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Comision { get; set; }



    }

}
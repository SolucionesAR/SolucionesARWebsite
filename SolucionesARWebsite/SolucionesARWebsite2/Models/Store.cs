using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class Store
    {
        /// <summary>
        /// 
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual District District { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferencePerson { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ReferencePersonNumber { get; set; }


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
        public virtual Company Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }

        

    }
}
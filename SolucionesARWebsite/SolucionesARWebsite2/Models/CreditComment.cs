using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class CreditComment
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public int CreditCommentId { get; set; }
        /// <summary>
        /// Comment text
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Comment date
        /// </summary>
        public DateTime CommentDate { get; set; }
        /// <summary>
        /// Credit Process object
        /// </summary>
        public CreditProcess CreditProcess { get; set; }
        /// <summary>
        ///  Credit Process id
        /// </summary>
        public int CreditProcessId { get; set; }
    }
}
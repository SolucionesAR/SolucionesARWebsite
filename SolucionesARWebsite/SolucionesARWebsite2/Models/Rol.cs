using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class Rol
    {
        /// <summary>
        /// 
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// /
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
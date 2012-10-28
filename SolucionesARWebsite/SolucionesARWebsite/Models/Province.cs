using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Canton> Cantons { get; set; }
    }
}
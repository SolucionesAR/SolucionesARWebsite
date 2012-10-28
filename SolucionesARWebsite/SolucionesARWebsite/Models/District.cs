using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public virtual Canton Canton { get; set; }

        public int CantonId { get; set; }
    }
}
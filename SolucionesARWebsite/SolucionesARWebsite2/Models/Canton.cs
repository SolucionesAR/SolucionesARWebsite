using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.Models
{
    public class Canton
    {
        public int CantonId { get; set; }

        public string Name { get; set; }

        public virtual Province Province { get; set; }

        public int ProvinceId { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
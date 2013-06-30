using System;
using System.Collections.Generic;

namespace SolucionesARWebsite2.Models
{
    public class Rol
    {
        public int RolId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
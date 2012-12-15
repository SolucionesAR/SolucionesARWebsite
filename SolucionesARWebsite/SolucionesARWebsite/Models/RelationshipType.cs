using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite.Models
{
    public class RelationshipType
    {
        /// <summary>
        /// The Unique RelationshipType identifier
        /// </summary>
        public int RelationshipTypeId { get; set; }

        /// <summary>
        /// The RelationshipType description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When the RelationshipType have been created
        /// </summary>
        public DateTime CreatetedAt { get; set; }

        /// <summary>
        /// Last time the RelationshipType is updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The list of relationships associated
        /// </summary>
        //public virtual ICollection<Relationship> Relationships { get; set; }//TODO: quitando relations


        /// <summary>
        /// The list of relationships associated
        /// </summary>
        public virtual ICollection<User> Users { get; set; }//TODO: quitando relations
    }
}
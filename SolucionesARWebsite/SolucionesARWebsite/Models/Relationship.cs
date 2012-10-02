using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolucionesARWebsite.Models
{
    public class Relationship
    {

        /// <summary>
        /// The Unique Relationship identifier
        /// </summary>
        public int RelationshipId { get; set; }

        /// <summary>
        /// When the Relationship have been created
        /// </summary>
        public DateTime CreatetedAt { get; set; }

        /// <summary>
        /// Last time the Relationship is updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        

        /// <summary>
        /// The first user id
        /// </summary>
        public int UserId1 { get; set; }

        /// <summary>
        /// The first user
        /// </summary>
        [ForeignKey("UserId1")]
        public virtual User User1 { get; set; }


        /// <summary>
        /// The second user id
        /// </summary>
        public int UserId2 { get; set; }

        /// <summary>
        /// The second user
        /// </summary>
        [ForeignKey("UserId2")]
        public virtual User User2 { get; set; }


        /// <summary>
        /// The Relationship Type 
        /// </summary>
        public virtual RelationshipType RelationshipType { get; set; }

        /// <summary>
        /// The RelationshipType Id
        /// </summary>
        public int RelationshipTypeId { get; set; }

    }
}
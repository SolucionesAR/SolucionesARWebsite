using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.Models
{
    public class User
    {
        /// <summary>
        /// The Unique user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public int CedNumber { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        public string LName1 { get; set; }

        /// <summary>
        /// The second Last Name
        /// </summary>
        public string LName2 { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        public string GeneratedCode { get; set; }

        /// <summary>
        /// The date of birth
        /// </summary>
        public DateTime Dob { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The address 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The cell phone number
        /// </summary>
        public string Cellphone { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// When the user have been created
        /// </summary>
        public DateTime CreatetedAt { get; set; }

        /// <summary>
        /// Last time the user is updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// To check if the user is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The total amount of users cash back 
        /// </summary>
        public double Cashback { get; set; }

        /// <summary>
        /// The users rol in the system
        /// </summary>
        public virtual Rol UserRol { get; set; }

        /// <summary>
        /// The Rol id
        /// </summary>
        public int RolId { get; set; }


        /// <summary>
        /// The reference user id
        /// </summary>
        public int UserReferenceId { get; set; }

        /// <summary>
        /// The reference user
        /// </summary>
        [ForeignKey("UserReferenceId")]
        public virtual User UserReference { get; set; }

    }
}
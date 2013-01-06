using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.Models
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
        public DateTime? Dob { get; set; }

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
        /// Any other telephone number available
        /// </summary>
        public string OtherPhones { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// When the user has been created
        /// </summary>
        public DateTime? CreatetedAt { get; set; }

        /// <summary>
        /// Last time the user is updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

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
        public int? UserReferenceId { get; set; }

        /// <summary>
        /// The reference user
        /// </summary>
        [ForeignKey("UserReferenceId")]
        public virtual User UserReference { get; set; }

        /// <summary>
        /// The reference to the identification type
        /// </summary>
        public virtual IdentificationType IdentificationType { get; set; }

        /// <summary>
        /// The identification type id
        /// </summary>
        public int IdentificationTypeId { get; set; }
        
        /// <summary>
        /// The user nationality
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// The password encryption key
        /// </summary>
        public string PasswordKey { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// The company reference
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// The company id
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Users profesion
        /// </summary>
        public string Profision { get; set; }

        /// <summary>
        /// Other products that the user sales
        /// </summary>
        public string OtherProducts { get; set; }

        /// <summary>
        /// Users personal references
        /// </summary>
        public string PersonalReference1 { get; set; }

        /// <summary>
        ///  Users personal references
        /// </summary>
        public string PersonalReference2 { get; set; }

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
        public int Points { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SinpeAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue (1)]
         public int RelationshipTypeId { get; set; }//TODO: quitando relations

        /// <summary>
        /// 
        /// </summary>
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Users
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public int IdentificationTypeId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public string IdentificationNumber { get; set; }
            
        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public string Nationality { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        [Required]
        public string LastName1 { get; set; }

        /// <summary>
        /// The second Last Name
        /// </summary>
        [Required]
        public string LastName2 { get; set; }

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
        /// The city
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The State
        /// </summary>
        public string State { get; set; }

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
        /// To check if the user is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        public int ParentUser { get; set; }

        /// <summary>
        /// The Rol id
        /// </summary>
        [Required]
        [DisplayName("Rol")]
        public int RolId { get; set; }

        /// <summary>
        /// The Company id
        /// </summary>
        public int CompanyId { get; set; }
        
        #endregion

        #region Private Members

        private int CedNumberInt { get; set; }

        #endregion

        #region Contructors
        #endregion

        #region Public Methods

        public void ValidateModel(ModelStateDictionary modelState)
        {
            int cedNumber;
            var isValidCedNumber = Int32.TryParse(IdentificationNumber, out cedNumber);
            if (isValidCedNumber)
            {
                CedNumberInt = cedNumber;
            }
            else
            {
                modelState.AddModelError("IdentificationNumber", "El número de cédula debe ser numérico.");
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
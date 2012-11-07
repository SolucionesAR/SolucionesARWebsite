using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SolucionesARWebsite.Models;

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
        public int UserId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public IdentificationType IdentificationType { get; set; }

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
        [Required]
        public DateTime Dob { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        [Required]
        public string Address1 { get; set; }

        /// <summary>
        /// The address 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The district
        /// </summary>
        [Required]
        public District District { get; set; }

        /// <summary>
        /// The canton
        /// </summary>
        [Required]
        public Canton Canton { get; set; }

        /// <summary>
        /// The province
        /// </summary>
        [Required]
        public Province Province { get; set; }

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
        public string ParentUser { get; set; }

        /// <summary>
        /// The Rol id
        /// </summary>
        public Rol UserRol { get; set; }

        /// <summary>
        /// The Company id
        /// </summary>
        public Company Company { get; set; }
        
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
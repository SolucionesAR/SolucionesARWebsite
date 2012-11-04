using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ModelsWebsite.Views.Users
{
    public class EditViewModel : BaseViewModel
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
        [Display(Name = "Tipo de Idenficación*")]
        public IdentificationType IdentificationType { get; set; }

        /// <summary>
        /// The Identification Types List
        /// </summary>
        public List<IdentificationType> IdentificationTypesList { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Identificacion*", Prompt = "Cédula - No. Passaporte")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// The Nationality
        /// </summary>
        [Display(Name = "Nacionalidad*", Prompt = "Nacionalidad")]
        public string Nationality { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string FirstName { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        [Required]
        [Display(Name = "Primer Apellido*", Prompt = "Primer Apellido")]
        public string LastName1 { get; set; }

        /// <summary>
        /// The second Last Name
        /// </summary>
        [Display(Name = "Segundo Apellido*", Prompt = "Segundo Apellido")]
        public string LastName2 { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        [DisplayName("Código")]
        public string GeneratedCode { get; set; }

        /// <summary>
        /// Cashback
        /// </summary>
        [DisplayName("Cashback")]
        public string Cashback { get; set; }

        /// <summary>
        /// The date of birth
        /// </summary>
        [Display(Name = "Fecha Nacimiento*", Prompt = "Fecha Nacimiento")]
        public DateTime Dob { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        [Display(Name = "Otras Señas", Prompt = "Dirección")]
        public string Address1 { get; set; }

        /// <summary>
        /// The address 2
        /// </summary>
        [Display(Name = "Dirección Complementaria", Prompt = "Dirección Complementaria")]
        public string Address2 { get; set; }

        /// <summary>
        /// The district
        /// </summary>
        [Display(Name = "Distrito", Prompt = "Distrito")]
        public string District { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        [Display(Name = "Cantón", Prompt = "Cantón")]
        public string City { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        [Display(Name = "Provincia", Prompt = "Provincia")]
        public string State { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        [Display(Name = "Teléfono Fijo", Prompt = "2222-2222")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The cell phone number
        /// </summary>
        [DisplayName("Célular")]
        [Display(Name = "Célular", Prompt = "8888-8888")]
        public string Cellphone { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        [DisplayName("Email")]
        [Display(Name = "Email", Prompt = "usuario@dominio.com")]
        public string Email { get; set; }

        /// <summary>
        /// To check if the user is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        [Display(Name = "Referente", Prompt = "Código Usuario Referente")]
        public string ParentUser { get; set; }

        /// <summary>
        /// The Rol id
        /// </summary>
        [Required]
        [DisplayName("Rol")]
        public Rol Rol { get; set; }

        /// <summary>
        /// The Roles List 
        /// </summary>
        public List<Rol> RolesList { get; set; }

        /// <summary>
        /// The Company id
        /// </summary>
        [DisplayName("Compañia")]
        public Company Company { get; set; }

        /// <summary>
        /// The Companies List
        /// </summary>
        public List<Company> CompaniesList { get; set; }


        #endregion

        #region Private Members
        #endregion

        #region Contructors
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
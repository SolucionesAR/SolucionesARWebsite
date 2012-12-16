using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Users
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
        [Required(ErrorMessage = "Favor completar el numero de idenficación")]
        [Display(Name = "Identificacion*", Prompt = "Cédula - No. Passaporte")]
        public string IdentificationNumber { get; set; }
            
        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        [Display(Name = "Nacionalidad*", Prompt = "Nacionalidad")]
        public string Nationality { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        [Required]
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
        [Required]
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
        [Required]
        [Display(Name = "Fecha Nacimiento*", Prompt = "Fecha Nacimiento")]
        public DateTime? Dob { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        [Required]
        [Display(Name = "Otras Señas", Prompt = "Dirección")]
        public string Address1 { get; set; }

        /// <summary>
        /// The address 2
        /// </summary>
        [Display(Name = "Otras Señas", Prompt = "Dirección Complementaria")]
        public string Address2 { get; set; }

        /// <summary>
        /// The district
        /// </summary>
        [Required]
        [Display(Name = "Distrito", Prompt = "Distrito")]
        public int DistrictId { get; set; }

        /// <summary>
        /// The canton
        /// </summary>
        [Required]
        [Display(Name = "Cantón", Prompt = "Cantón")]
        public int CantonId { get; set; }

        /// <summary>
        /// The province
        /// </summary>
        [Required]
        [Display(Name = "Provincia", Prompt = "Provincia")]
        public int ProvinceId { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        [Display(Name = "Teléfono Fijo", Prompt = "2222-2222")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The cell phone number
        /// </summary>
        [Display(Name = "Célular", Prompt = "8888-8888")]
        public string Cellphone { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        [Display(Name = "Email", Prompt = "usuario@dominio.com")]
        public string Email { get; set; }

        /// <summary>
        /// To check if the user is enabled
        /// </summary>
        [DisplayName("Habilitado")]
        public bool Enabled { get; set; }

        /// <summary>
        /// A code that will be generated automatically to each user
        /// </summary>
        [Display(Name = "Referente", Prompt = "Codigo del Referente")]
        [Remote("IsValidParentUser", "Users", ErrorMessage = "El usuario no ingresado no cumple con los requisitos")]
        public string UserReference { get; set; }

        /// <summary>
        /// The Rol id
        /// </summary>
        [Required]
        [Display(Name = "Rol*")]
        public Rol UserRol { get; set; }

        /// <summary>
        /// The Roles List 
        /// </summary>
        public List<Rol> RolesList { get; set; }

        /// <summary>
        /// The Company
        /// </summary>
        [Required]
        [Display(Name = "Compañia*")]
        public Company Company { get; set; }

        /// <summary>
        /// The Companies List
        /// </summary>
        public List<Company> CompaniesList { get; set; }

        /// <summary>
        /// The Relationship Type
        /// </summary>
        [Required]
        [Display(Name = "Nivel")]
        public RelationshipType RelationshipType { get; set; }

        /// <summary>
        /// The Relationship List
        /// </summary>
        public List<RelationshipType> RelationshipTypeList { get; set; }
        
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
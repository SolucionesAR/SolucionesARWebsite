using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Users
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        public int UserId { get; set; }

        [Required]
        [DisplayName("Número de cédula")]
        public int CedNumber { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string FName { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        public string LName1 { get; set; }

        [Required]
        [DisplayName("Segundo Apellido")]
        public string LName2 { get; set; }

        [Required]
        [DisplayName("Código Generado")]
        public string GeneratedCode { get; set; }

        [Required]
        [DisplayName("Fecha Nacimiento")]
        public DateTime Dob { get; set; }

        [Required]
        [DisplayName("Dirección Primaria")]
        public string Address1 { get; set; }

        [DisplayName("Dirección Complementaria")]
        public string Address2 { get; set; }

        [DisplayName("Teléfono")]
        public string PhoneNumber { get; set; }

        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [DisplayName("Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Habilidato")]
        public bool Enabled { get; set; }

        [Required]
        [DisplayName("Cashback")]
        public double Cashback { get; set; }

        [Required]
        [DisplayName("Rol")]
        public int RolId { get; set; }

        public DateTime CreatetedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


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
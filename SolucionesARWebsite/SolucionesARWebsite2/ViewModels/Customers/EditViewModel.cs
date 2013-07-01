using System;
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Customers
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The customer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The First Name
        /// </summary>
        [Required(ErrorMessage = "Favor completar el nombre del cliente")]
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string FName { get; set; }

        /// <summary>
        /// The first Last Name
        /// </summary>
        [Required(ErrorMessage = "Favor completar los apellidos")]
        [Display(Name = "Apellidos*", Prompt = "Apellidos")]
        public string LName { get; set; }
        
        /// <summary>
        /// The ced number
        /// </summary>
        [Required(ErrorMessage = "Favor completar el numero de idenficación")]
        [Display(Name = "Identificacion*", Prompt = "Cédula - No. Passaporte")]
        public string CedNumber { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        [Display(Name = "Teléfono", Prompt = "8888-8888")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Company where the customer works
        /// </summary>
        [Display(Name = "Empleador", Prompt = "Empleador")]
        public string Boss { get; set; }

        /// <summary>
        /// Customer possition
        /// </summary>
        [Display(Name = "Puesto", Prompt = "Puesto")]
        public string Possition { get; set; }

        /// <summary>
        /// Salary per month
        /// </summary>
        [Display(Name = "Salario", Prompt = "0")]
        public string Salary { get; set; }

        /// <summary>
        /// Laboral Time
        /// </summary>
        [Display(Name = "Tiempo de Laborar", Prompt = "Años")]
        public string LaboralTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }
        #endregion
        
        #region Contructors
        #endregion

        #region Public Methods
        
        #endregion

        #region Private Methods

        #endregion
    }
}
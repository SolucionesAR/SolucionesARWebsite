using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ModelsWebsite.Views.Stores
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Identification number
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// The store name
        /// </summary>
        [Display(Name = "Nombre*", Prompt = "Nombre")]
        public string StoreName { get; set; }

        /// <summary>
        /// The Company id
        /// </summary>
        [DisplayName("Compañia")]
        public Company Company { get; set; }

        /// <summary>
        /// The Companies List
        /// </summary>
        public List<Company> CompaniesList { get; set; }

        /// <summary>
        /// The address 1
        /// </summary>
        [Display(Name = "Otras Señas", Prompt = "Dirección")]
        public string Address { get; set; }

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
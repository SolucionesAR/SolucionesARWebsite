using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Views.Stores
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
        /// 
        /// </summary>
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Distrito")]
        public District District { get; set; }

        /// <summary>
        /// 
        /// </summary>  
        public List<District> Districts { get; set; }


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
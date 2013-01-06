using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Stores
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

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
        [DisplayName("Teléfono 1")]
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Teléfono 2")]
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Número de Fax")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// The district
        /// </summary>
        [Display(Name = "Distrito", Prompt = "Distrito")]
        public District District { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        [Display(Name = "Cantón", Prompt = "Cantón")]
        public Canton Canton { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        [Display(Name = "Provincia", Prompt = "Provincia")]
        public Province Province { get; set; }

        /// <summary>
        /// The districts list
        /// </summary>
        public List<District> DistrictsList { get; set; }

        /// <summary>
        /// The cities list
        /// </summary>
        public List<Canton> CantonsList { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        public List<Province> ProvincesList { get; set; }


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
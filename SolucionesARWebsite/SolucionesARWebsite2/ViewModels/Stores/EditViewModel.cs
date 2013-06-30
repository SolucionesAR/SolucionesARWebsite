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
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// The Company id
        /// </summary>
        [DisplayName("Compañia")]
        [Required]
        public Company Company { get; set; }

        /// <summary>
        /// The Companies List
        /// </summary>
        public List<Company> CompaniesList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Teléfono 1", Prompt = "2222-2222")]
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Teléfono 2", Prompt = "2222-2222")]
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Número de Fax", Prompt = "2222-2222")]
        public string FaxNumber { get; set; }
        
        /// <summary>
        /// The district
        /// </summary>
        [Required(ErrorMessage = "Favor seleccionar un distrito ")]
        [Display(Name = "Distrito", Prompt = "Distrito")]
        public int DistrictId { get; set; }

        /// <summary>
        /// The canton
        /// </summary>
        [Required(ErrorMessage = "Favor seleccionar un cantón")]
        [Display(Name = "Cantón", Prompt = "Cantón")]
        public int CantonId { get; set; }

        /// <summary>
        /// The province
        /// </summary>
        [Required(ErrorMessage = "Favor seleccionar una provincia")]
        [Display(Name = "Provincia", Prompt = "Provincia")]
        public int ProvinceId { get; set; }

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
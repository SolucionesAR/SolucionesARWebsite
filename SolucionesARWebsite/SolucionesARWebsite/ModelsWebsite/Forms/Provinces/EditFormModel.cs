using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Provinces
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
        public int ProvinceId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public string ProvinceName { get; set; }

        
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
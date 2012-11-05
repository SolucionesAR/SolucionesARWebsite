using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolucionesARWebsite.ModelsWebsite.Forms.Cantons
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required]
        public int CantonId { get; set; }

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        [Required]
        public int ProvinceId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public string CantonName { get; set; }

        
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
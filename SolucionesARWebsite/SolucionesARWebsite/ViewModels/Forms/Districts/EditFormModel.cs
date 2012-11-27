using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolucionesARWebsite.ViewModels.Forms.Districts
{
    public class EditFormModel
    {
        #region Constants
        #endregion

        #region Properties

        [Required]
        public int DistrictId { get; set; }

        /// <summary>
        /// The Unique user identifier
        /// </summary>
        [Required]
        public int CantonId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Required]
        public string DistrictName { get; set; }

        
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
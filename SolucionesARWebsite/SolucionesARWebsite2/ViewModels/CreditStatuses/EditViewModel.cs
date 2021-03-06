﻿using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.CreditStatuses
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Credit Status id
        /// </summary>
        [Required]
        public int CreditStatusId { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [Display(Name = "Descripcion*", Prompt = "Descripcion")]
        [Required(ErrorMessage = "Descripcion es requerida")]
        public string CreditStatusDescription { get; set; }
        
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
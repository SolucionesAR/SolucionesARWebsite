using System.Collections.Generic;
using System.ComponentModel;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Views.Inventory
{
    public class UploadViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Company id
        /// </summary>
        [DisplayName("Compañia")]
        public Company Company { get; set; }

        /// <summary>
        /// The Companies List
        /// </summary>
        public List<Company> CompaniesList { get; set; }

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
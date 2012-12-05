using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite.ViewModels.Views.RelationshipTypes
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// The Unique company identifier
        /// </summary>
        public int RelationshipTypesId { get; set; }

        /// <summary>
        /// The Identification number
        /// </summary>
        [Display(Name = "Descripcion*", Prompt = "Descripcion")]
        public string Description { get; set; }

        
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
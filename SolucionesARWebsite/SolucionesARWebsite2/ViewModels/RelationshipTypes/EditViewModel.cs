using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.RelationshipTypes
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        public int RelationshipTypesId { get; set; }

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
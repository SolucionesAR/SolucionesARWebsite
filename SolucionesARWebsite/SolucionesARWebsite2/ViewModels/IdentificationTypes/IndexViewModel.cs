using PagedList;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.IdentificationTypes
{
    public class IndexViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// Displayed items
        /// </summary>
        public IPagedList<IdentificationType> PagedItems { get; set; }

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
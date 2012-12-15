using PagedList;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Provinces
{
    public class IndexViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// Displayed items
        /// </summary>
        public IPagedList<Province> PagedItems { get; set; }

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
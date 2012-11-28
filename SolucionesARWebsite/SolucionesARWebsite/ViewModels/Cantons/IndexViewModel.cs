using PagedList;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Cantons
{
    public class IndexViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// Displayed items
        /// </summary>
        public IPagedList<Canton> PagedItems { get; set; }

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
using PagedList;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Users
{
    public class IndexViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties
        
        public IPagedList<User> PagedItems { get; set; }

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
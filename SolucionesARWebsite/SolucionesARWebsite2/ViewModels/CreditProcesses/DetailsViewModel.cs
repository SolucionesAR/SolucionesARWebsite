using PagedList;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.CreditProcesses
{
    public class DetailsViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties

        public IPagedList<CreditComment> PagedItems { get; set; }

        public int CreditProcessXCompanyId { get; set; }

        public int CreditProcessId { get; set; }

        public string Comment { get; set; }

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
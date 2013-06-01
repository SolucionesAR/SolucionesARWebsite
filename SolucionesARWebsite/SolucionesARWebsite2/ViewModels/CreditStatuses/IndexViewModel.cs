using PagedList;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.CreditStatuses    
{
    public class IndexViewModel : BaseListModel
    {
        #region Constants
        #endregion

        #region Properties

        public IPagedList<Models.CreditStatus> PagedItems { get; set; } //TODO: ver por que este no lo agarra con el using

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
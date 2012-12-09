using PagedList;
namespace SolucionesARWebsite.ViewModels.Reports
{
    public class IndexViewModel : BaseListModel
    {
        #region Properties

        public IPagedList<Report> PagedItems { get; set; }

        #endregion
    }
}
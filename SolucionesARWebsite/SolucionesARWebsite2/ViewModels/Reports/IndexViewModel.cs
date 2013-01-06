using PagedList;
namespace SolucionesARWebsite2.ViewModels.Reports
{
    public class IndexViewModel : BaseListModel
    {
        #region Properties

        public IPagedList<Report> PagedItems { get; set; }

        #endregion
    }
}
using System.Collections;
using PagedList;

namespace SolucionesARWebsite.ViewModels
{
    /// <summary>
    /// Holds sorting and pagination data.
    /// </summary>
    public class BaseListModel : BaseViewModel
    {
        public int? Page { get; set; }
        public string EmailAddress { get; set; }
        public string LastName { get; set; }
        public string SearchButton { get; set; }
        public IList Items { get; set; }
    }
}
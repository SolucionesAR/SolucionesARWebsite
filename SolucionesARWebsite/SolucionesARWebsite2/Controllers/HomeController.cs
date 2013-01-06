using System.Web.Mvc;
using SolucionesARWebsite2.Business.Management;

namespace SolucionesARWebsite2.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor

        public HomeController(UsersManagement usersManagement)
            : base(usersManagement)
        {
        }

        #endregion

        #region Public Actions
        
        public ActionResult Index()
        {
            return View();
        }

        #endregion 
    }
}
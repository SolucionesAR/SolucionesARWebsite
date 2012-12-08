using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;

namespace SolucionesARWebsite.Controllers
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
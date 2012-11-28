using System.Web.Mvc;

namespace SolucionesARWebsite.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor
        
        #endregion

        #region Public Actions
        
        public ActionResult Index()
        {
            return View();
        }

        #endregion 
    }
}
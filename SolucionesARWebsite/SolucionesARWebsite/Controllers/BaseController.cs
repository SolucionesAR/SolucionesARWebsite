using System.Web.Mvc;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Controllers
{
    public class BaseController : Controller
    {
        #region Constants

        #endregion

        #region Properties
        
        #endregion

        #region Private Members

        private readonly DbModel _entityModel = new DbModel();

        #endregion

        #region Protected Method

        protected override void Dispose(bool disposing)
        {
            _entityModel.Dispose();
            base.Dispose(disposing);
        }

        #endregion
        #region Public Actions
        #endregion

        #region Private Members
        #endregion
    }
}
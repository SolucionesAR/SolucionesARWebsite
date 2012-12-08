using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;

namespace SolucionesARWebsite.Controllers
{
    public class ReportsController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members
        
        #endregion

        #region Constructors

        public ReportsController(UsersManagement usersManagement)
            : base(usersManagement)
        {
        }

        #endregion

        #region Public Actions

        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return null;
        }

        //
        //
        // GET: /Roles/Create

        public ActionResult GenerateReport(int reportId)
        {
            return null;
        }

        #endregion
    }
}
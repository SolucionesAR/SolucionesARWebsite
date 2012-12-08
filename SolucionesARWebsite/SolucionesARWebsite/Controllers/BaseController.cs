using System.Web.Security;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.DataAccess.Repositories;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Controllers
{
    public class BaseController : SecuredController
    {
        #region Constants

        public int PageSize = 10;

        public int FirstPage = 1;

        #endregion

        #region Properties  
        #endregion

        #region Private Members

        private readonly DbModel _entityModel = new DbModel();
        protected readonly UsersManagement UsersManagement;

        #endregion

        #region Constructors

        public  BaseController(UsersManagement usersManagement)
        {
            UsersManagement = usersManagement;
            CreateSecurityContext();
        }

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

        /// <summary>
        /// Creates the security context.
        /// </summary>
        private void CreateSecurityContext()
        {
            if (SecurityContext == null)
            {
                var identity = System.Web.HttpContext.Current.User.Identity;
                if (identity.IsAuthenticated && !string.IsNullOrEmpty(identity.Name))
                {
                    SecurityContext = new SecurityContext
                                          {
                                              User = UsersManagement.GetUserInformation(identity.Name),
                                          };
                }
                else
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        #endregion
    }
}
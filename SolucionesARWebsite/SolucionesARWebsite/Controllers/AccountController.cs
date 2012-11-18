using System.Web.Mvc;
using System.Web.Security;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.ModelsWebsite.Views.Account;
using WebMatrix.WebData;
using SolucionesARWebsite.ModelsWebsite.Forms.Account;

namespace SolucionesARWebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly UsersAccess _usersAccess;

        #endregion

        #region Constructors

        public AccountController()
        {
            _usersAccess = new UsersAccess();
        }

        #endregion

        #region Public Actions
        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            HttpContext.Response.Cookies.Remove("__RequestVerificationToken_Lw__");
            /*
            var homePage = ThemeHelper.GetData(ThemeDataKey.HomePage);
            if (!string.IsNullOrEmpty(homePage) && (access == null || !access.Value))
                return Redirect(homePage);

            if (_authManager.IsLoggedIn())
                return Redirect(_authManager.GetDefaultUrl());
            */
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginFormModel loginFormModel, string returnUrl)
        {
            //if (ModelState.IsValid && _accountLogic.IsValidLogin(loginFormModel))
            if(true)
            {
                FormsAuthentication.SetAuthCookie(loginFormModel.Username, false);
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            var loginViewModel = new LoginViewModel
                                     {
                                         Username = loginFormModel.Username,
                                     };
            return View(loginViewModel);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Helpers
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}

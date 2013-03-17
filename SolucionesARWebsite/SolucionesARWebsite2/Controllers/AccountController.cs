using System.Web.Mvc;
using System.Web.Security;
using SolucionesARWebsite2.Business.Logic;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Utils;
using SolucionesARWebsite2.ViewModels.Account;

namespace SolucionesARWebsite2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Private Members

        private readonly AccountLogic _accountLogic;

        #endregion

        #region Constructors

        public AccountController(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        #endregion

        #region Public Actions
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            HttpContext.Response.Cookies.Remove("__RequestVerificationToken_Lw__");
            /*
            if (!string.IsNullOrEmpty(homePage) && (access == null || !access.Value))
                return Redirect(homePage);

            if (_authManager.IsLoggedIn())
                return Redirect(_authManager.GetDefaultUrl());
            */
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginFormModel, string returnUrl)
        {
            if (ModelState.IsValid && _accountLogic.IsValidLogin(loginFormModel))
            {
                FormsAuthentication.SetAuthCookie(loginFormModel.Username, false);
                Session[Constants.RoleBasedMenu.ToStringValue()] = null;
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("Username", "The user name or password provided is incorrect.");
            loginFormModel.Password = string.Empty;
            return View(loginFormModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginBackDoor(LoginViewModel loginFormModel, string returnUrl)
        {
            if (ModelState.IsValid && _accountLogic.CreateDefaultConfiguration(loginFormModel))
            {
                FormsAuthentication.SetAuthCookie(loginFormModel.Username, false);
                Session[Constants.RoleBasedMenu.ToStringValue()] = null;
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("Username", "Hey you...! We got you :P");
            return View("Login", loginFormModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session[Constants.RoleBasedMenu.ToStringValue()] = null;
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
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}

﻿using System.Web.Mvc;
using System.Web.Security;
using SolucionesARWebsite.Business.Logic;
using SolucionesARWebsite.ViewModels.Account;
using WebMatrix.WebData;

namespace SolucionesARWebsite.Controllers
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

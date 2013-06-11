using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.Controllers
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
        protected readonly UsersManagement _usersManagement;

        #endregion

        #region Constructors

        public  BaseController(UsersManagement usersManagement)
        {
            _usersManagement = usersManagement;
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
        
        public List<User> GetAvailableUsersList()
        {
            var availableUsersList = Session[Constants.AvailableUsers.ToStringValue()] as List<User>;
            
            if (availableUsersList == null)
            {
                UpdateAvailableUsersList();
                availableUsersList = Session[Constants.AvailableUsers.ToStringValue()] as List<User>;
            }
            return availableUsersList;
        }

        public void UpdateAvailableUsersList()
        {
            var availableUsersList = _usersManagement.GetUsersList();
            Session[Constants.AvailableUsers.ToStringValue()] = availableUsersList;
        }

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
                                              User = _usersManagement.GetUserInformation(identity.Name),
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
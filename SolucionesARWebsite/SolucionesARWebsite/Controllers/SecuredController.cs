using System;
using System.Net;
using System.Web.Mvc;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Exceptions;
using SolucionesARWebsite.Security;

namespace SolucionesARWebsite.Controllers
{
    /// <summary>
    /// Base controller only used after authentication
    /// </summary>
    [Authorize]
    public abstract class SecuredController : AsyncController
    {
        /// <summary>
        /// Required key for retrieving the security context
        /// </summary>
        public const string SECURITY_CONTEXT_KEY = "@@SecurityContext";

        /// <summary>
        /// Gets or sets the security context.
        /// </summary>
        /// <value>The security context.</value>
        protected SecurityContext SecurityContext
        {
            get
            {
                return System.Web.HttpContext.Current.Session[SECURITY_CONTEXT_KEY] as SecurityContext;
            }
            set
            {
                System.Web.HttpContext.Current.Session[SECURITY_CONTEXT_KEY] = value;
            }
        }

        /// <summary>
        /// Clears the security context.
        /// </summary>
        protected void ClearSecurityContext()
        {
            SecurityContext = null;
        }
        
        /// <summary>
        /// Validates the action execution.
        /// </summary>
        /// <param name="securityRole">The security role.</param>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        private static void ValidateActionExecution(SecurityRol securityRole, string action, string controller)
        {
            if (!securityRole.AllowAction(action, controller))
            {
                throw GetUnautorizedException(controller, action);
            }
        }

        /// <summary>
        /// Throws the unautorized exception.
        /// </summary>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action</param>
        /// <returns></returns>
        public static UnautorizedException GetUnautorizedException(string controller, string action)
        {
            return new UnautorizedException((int)HttpStatusCode.Forbidden, "Usuario no tiene sufientes permisos para ejecutar la accion seleccionada ", controller, action);
        }

        /// <summary>
        /// Throws the unautorized exception.
        /// </summary>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action</param>
        /// <param name="parameters">An string with all the parameters</param>
        /// <returns></returns>
        public static UnautorizedException GetUnautorizedException(string controller, string action, string parameters)
        {
            return new UnautorizedException((int)HttpStatusCode.Forbidden, "Usuario no tiene sufientes permisos para ejecutar la accion seleccionada", controller, action, parameters);
        }

        /// <summary>
        /// Throws the unautorized exception.
        /// </summary>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action</param>
        /// <param name="id">The parameter id</param>
        /// <returns></returns>
        public static UnautorizedException GetUnautorizedException(string controller, string action, int id)
        {
            return new UnautorizedException((int)HttpStatusCode.Forbidden, "Usuario no tiene sufientes permisos para ejecutar la accion seleccionada", controller, action, Convert.ToString(id));
        }

        /// <summary>
        /// Method called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Contains information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SecurityContext != null)
            {
                var securityRole = RolesProvider.GetSecurityRole(SecurityContext.User.Role, filterContext.HttpContext.Request);
                ValidateActionExecution(securityRole, filterContext.ActionDescriptor.ActionName,
                                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            }
        }
    }
}
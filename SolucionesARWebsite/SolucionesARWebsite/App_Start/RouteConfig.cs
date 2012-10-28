using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
            /*
            // DEFAULT ROUTE
            routes.MapRoute(
                "DefaultRoute", // Route name
                "", // URL with parameters
                new
                    {
                        controller = Enumerations.Controllers.Account.ToStringValue(),
                        action = Enumerations.AccountActions.Login.ToStringValue(),
                    } // Parameter defaults
                );

            // CONTROLLER + ACTION + ID ROUTE
            routes.MapRoute(
                null, // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {}, // Parameter defaults
                new
                    {
                        id = @"\d+",
                    } // Numerical constraints
                );

            // CONTROLLER + ACTION ROUTE
            routes.MapRoute(
                null, // Route name
                "{controller}/{action}", // URL with parameters
                new {} // Parameter defaults
                );
        */
        }
    }
}
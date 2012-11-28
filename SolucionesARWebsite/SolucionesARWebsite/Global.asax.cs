﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataAccess.Repositories;

namespace SolucionesARWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Register dependencies with Autofac
            RegisterDependencies();
            
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Repositories
            builder.RegisterType<CompaniesRepository>().As<ICompaniesRepository>().InstancePerHttpRequest();
            builder.RegisterType<CantonsRepository>().As<ICantonsRepository>().InstancePerHttpRequest();
            builder.RegisterType<DistrictsRepository>().As<IDistrictsRepository>().InstancePerHttpRequest();
            builder.RegisterType<UsersRepository>().As<IUsersRepository>().InstancePerHttpRequest();

            //Managements
            builder.RegisterType<CantonsManagement>().InstancePerHttpRequest();
            builder.RegisterType<CompaniesManagement>().InstancePerHttpRequest();
            builder.RegisterType<DistrictsManagement>().InstancePerHttpRequest();
            builder.RegisterType<UsersManagement>().InstancePerHttpRequest();
 
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
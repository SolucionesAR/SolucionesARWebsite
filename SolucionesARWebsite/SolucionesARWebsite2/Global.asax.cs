using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SolucionesARWebsite2.App_Start;
using SolucionesARWebsite2.Business.Logic;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataAccess.Repositories;

namespace SolucionesARWebsite2
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
            builder.RegisterType<CantonsRepository>().As<ICantonsRepository>().InstancePerHttpRequest();
            builder.RegisterType<CompaniesRepository>().As<ICompaniesRepository>().InstancePerHttpRequest();
            builder.RegisterType<CreditStatusesRepository>().As<ICreditStatusesRepository>().InstancePerHttpRequest();
            builder.RegisterType<CreditProcessesRepository>().As<ICreditProcessesRepository>().InstancePerHttpRequest();
            builder.RegisterType<CustomersRepository>().As<ICustomersRepository>().InstancePerHttpRequest();
            builder.RegisterType<DistrictsRepository>().As<IDistrictsRepository>().InstancePerHttpRequest();
            builder.RegisterType<IdentificationTypesRepository>().As<IIdentificationTypesRepository>().InstancePerHttpRequest();
            builder.RegisterType<ProvincesRepository>().As<IProvincesRepository>().InstancePerHttpRequest();
            builder.RegisterType<RelationshipTypesRepository>().As<IRelationshipTypesRepository>().InstancePerHttpRequest();
            builder.RegisterType<RolesRepository>().As<IRolesRepository>().InstancePerHttpRequest();
            builder.RegisterType<StoresRepository>().As<IStoresRepository>().InstancePerHttpRequest();
            builder.RegisterType<TransactionsRepository>().As<ITransactionsRepository>().InstancePerHttpRequest();
            builder.RegisterType<UsersRepository>().As<IUsersRepository>().InstancePerHttpRequest();
            builder.RegisterType<CreditProcessLogsRepository>().As<ICreditProcessLogsRepository>().InstancePerHttpRequest();
            builder.RegisterType<CustomersRepository>().As<ICustomersRepository>().InstancePerHttpRequest();

            //Logic
            builder.RegisterType<AccountLogic>().InstancePerHttpRequest();
            builder.RegisterType<TransactionsLogic>().InstancePerHttpRequest();

            //Management
            builder.RegisterType<CantonsManagement>().InstancePerHttpRequest();
            builder.RegisterType<CompaniesManagement>().InstancePerHttpRequest();
            builder.RegisterType<CreditProcessesManagement>().InstancePerHttpRequest();
            builder.RegisterType<CreditStatusesManagement>().InstancePerHttpRequest();
            builder.RegisterType<CustomersManagement>().InstancePerHttpRequest();
            builder.RegisterType<DistrictsManagement>().InstancePerHttpRequest();
            builder.RegisterType<IdentificationTypesManagement>().InstancePerHttpRequest();
            builder.RegisterType<ProvincesManagement>().InstancePerHttpRequest();
            builder.RegisterType<RelationshipTypesManagement>().InstancePerHttpRequest();
            builder.RegisterType<RolesManagement>().InstancePerHttpRequest();
            builder.RegisterType<TransactionsManagement>().InstancePerHttpRequest();
            builder.RegisterType<UsersManagement>().InstancePerHttpRequest();
            builder.RegisterType<StoresManagement>().InstancePerHttpRequest();
            builder.RegisterType<CustomersManagement>().InstancePerHttpRequest();
            builder.RegisterType<CreditProcessLogsManagement>().InstancePerHttpRequest();
             
            builder.RegisterType<BeginningConfig>().InstancePerHttpRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Name.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Name.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        private static IContainer Container { get; set; }

        private void Application_Start(object sender, EventArgs e)
        {
            var container = SetupDependencyInjection();
            var config = GlobalConfiguration.Configuration;

            //MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();

            //Api
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private IContainer SetupDependencyInjection()
        {
            var builder = new ContainerBuilder();

            //Register our mvc controller 
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Register api controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            //Register module
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterModule(new AutofacBusinessRegister());

            Container = builder.Build();
            return Container;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using NorthWindWebAPI.CustomFilters;
using NorthWindWebAPI.ViewModel;

namespace NorthWindWebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelStateAttribute());

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            //Call Autofac DI bootstrapper class to register all the dependencies
            IocConfig.RegisterDependencies();
            //Call  Automapper bootstrapper class to create all the mappings
            AutomapperConfig.RegisterMappings();

          

        }
    }
}

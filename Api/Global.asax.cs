using Api.Modules;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(config =>
            {
                WebApiConfig.Register(config);
                SetupDependencyInjection(config);
            });

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void SetupDependencyInjection(HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<RepositoryModule>();

            builder.RegisterHttpRequestMessage(httpConfig);

            var container = builder.Build();

            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

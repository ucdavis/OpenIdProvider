using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OpenIdProvider
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // We will only ever need the razor view engine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
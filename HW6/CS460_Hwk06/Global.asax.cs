using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// added these two in b/c of snippet from Dr. Morse
using Microsoft.SqlServer.Types;
using System.Data.Entity.SqlServer;

namespace CS460_Hwk06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // ADDED PER LAB INSTRUCTIONS:
            // For Spatial types, i.e. DbGeography
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            // This next line is a fix that came from: 
            // https://stackoverflow.com/questions/13174197/microsoft-sqlserver-types-version-10-or-higher-could-not-be-found-on-azure/40166192#40166192
            SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

﻿using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XWingLeague.DatabaseMigrations;

namespace XWingLeague
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitialiseDatabase();
        }

        private static void InitialiseDatabase()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["XWingLeague"];
            var databaseMigrator = new Migrator(connectionStringSettings.ConnectionString);
            databaseMigrator.MigrateToLatestSchema();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Repository.Models;
using System.Data.Entity;
using Repository.Domain;

namespace Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Database.SetInitializer(new FacilityInitializer() );
            //Database.SetInitializer<FacilityContext>(new CreateDatabaseIfNotExists<FacilityContext>());
            //Database.SetInitializer<FacilityContext>(new DropCreateDatabaseIfModelChanges<FacilityContext>());
            //Database.Migrate();
            Database.SetInitializer<FacilityContext>(null);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}

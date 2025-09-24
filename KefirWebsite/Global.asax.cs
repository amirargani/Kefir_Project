using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity.Validation;
using KefirWebsite.Filter;

namespace KefirWebsite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            Application["Online"] = 0;

            GlobalConfiguration.Configuration.Filters.Add(new DBValidateFilter());
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            Application["Online"] = (int)Application["Online"] + 1;
            //    Application.UnLock();
        }
        protected void Session_End(object sender, EventArgs e)
        {
            //   Application.Lock();
            Application["Online"] = (int)Application["Online"] - 1;
        }
    }

    
}
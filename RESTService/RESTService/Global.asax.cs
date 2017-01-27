using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using RESTService.Infrastructure;
using Ninject.Web.Common;

namespace RESTService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.Routes.MapHttpRoute("MyRoute", "{controller}");
        }
    }
}

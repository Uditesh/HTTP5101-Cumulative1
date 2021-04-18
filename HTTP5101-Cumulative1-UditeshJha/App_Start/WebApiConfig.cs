using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HTTP5101_Cumulative1_UditeshJha
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{actions}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

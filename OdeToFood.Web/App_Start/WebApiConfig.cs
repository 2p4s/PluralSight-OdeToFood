using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdeToFood.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", //Notice its using api word as the trigger for the api route
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

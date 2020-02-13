using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //ignore certain types of routes e.g. trace.axd/1/2/3/4
            //anything in curly brackets becomes a template/ this wild card below looks for any occurance of the variable in pathInfo
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //main route template
            routes.MapRoute(
                name: "Default",    //name of the route

                //remember if we pass something other than named "Id", it will pass the element as a querystring item
                url: "{controller}/{action}/{id}",  //placeholder names
                //set the system defaults
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

// Custom class to configure autofac, need to change namespace
namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            //define autofac builder
            var builder = new ContainerBuilder();
            //scan through all controllers in the MVC application (this project) and indexes them
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //register API controllers too
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //tell container builder about specific types
            //asking for IRestaurantData will return InMemoryRestaurantData
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                //.SingleInstance();  //use a single instance, ie. shared instance as a singleton
                .InstancePerRequest();  //use an instance for this httpRequest.

            //register the type it requires to be injected into the constructor
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            //build the container based on the configuration given above
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //do the api config dependency resolver
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
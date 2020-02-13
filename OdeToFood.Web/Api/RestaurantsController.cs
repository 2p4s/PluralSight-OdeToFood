using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web
{
    public class RestaurantsController : ApiController  //Api controller type
    {
        //route goes to api/{controller}/{id}
        //supports get and post in place for actions
        //default it get

        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;

        }

        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }

        
    }
}

using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        //create db interface
        IRestaurantData db;


        //create constructor (quick type ctor)
        public HomeController(IRestaurantData db)
        {
            //hardcode data access
            //db = new InMemoryRestaurantData();

            //dependancy inversion principle   (soliD)
            this.db = db;
        }

        public ActionResult Index()
        {
            //return a test string, including html
            //return "<h1>Yo, whassappenin</h1>";

            //Get all the items in this instance
            var model = db.GetAll();
            //render the data
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
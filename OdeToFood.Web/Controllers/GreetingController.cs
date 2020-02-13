using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller    //HTML specific controller type
    {
        // GET: Greeting
        public ActionResult Index(string name)  //will automatically search for "name" in querystring
        {
            //build a model specific for this controller
            var model = new GreetingViewModel();
            //get querystring (old pre-MVC)
            //var name = HttpContext.Request.QueryString["Name"];
            model.Name = name ?? "no name";

            //load the message from the model from app settings
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }
    }
}
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;

        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        //having a parameter here means it will look in the querystring and routing for this id int
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            //should check if the model exists rather than inline if's
            if (model == null)
            {
                //go to a different controller
                //return RedirectToAction("Index");

                //return a specific view
                return View("NotFound");
            }

            //must have a model
            return View(model);
        }

        //returns the blank form to create, only responds to a get
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //will automatically pass the object values through correctly
        //only responds to a post
        [HttpPost]
        //need to ensure the anti-forgery token is valid
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //should validate against the model
            //low level validation
            //if (String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}
            //Model validation using data annotations, means adding required to the classes

            if (ModelState.IsValid)
            {
                //Its all good
                db.Add(restaurant);
                //saved OK, so need to redirect to elsewhere, going to details will require an id, accessed via object
                return RedirectToAction("Details", new { id = restaurant.Id });
            }


            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //get this specific model
            var model = db.Get(Id);
            //check we have an item, return null if not
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //now take care of the save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            //check if the modelstate is valid and passes validation
            if (ModelState.IsValid)
            {
                //save it now
                db.Update(restaurant);

                //its all good in the hood, redirector
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);

        }

        //For the delete request, we need to confirm the action
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //find the restaurant to confirm its details to the user
            var model = db.Get(id);
            //check its not null
            if (model == null)
            {
                return View("NotFound");
            }
            //load the page with the details
            return View(model);
        }

        //as this function has the same specification as the post and get it will error.
        //we create a dummy reference to a formcollection which does nothing other than give us a different signature.
        //seems odd to say the least.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
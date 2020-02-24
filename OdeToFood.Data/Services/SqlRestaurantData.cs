using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData        
    {
        private readonly OdeToFoodDbContext db;

        //pass a reference to the db context, configured elsewhere
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            //this statement will check the constraints in the db class
            db.Restaurants.Add(restaurant);
            //commit changes, by creating an insert statement
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //delete it from the db using Linq to find it
            var restaurant = db.Restaurants.Find(id);
            //should check we have found it here
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            //return the first where it matches or return null
            return db.Restaurants.FirstOrDefault( r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;

        }

        public void Update(Restaurant restaurant)
        {
            //get changes into the restaurant object, but be aware that mulitple users could be updating the same item
            //var r = Get(restaurant.Id);
            //r.Name = "";

            //This method checks that it matches whats in the database before saving
            var entry =db.Entry(restaurant);
            entry.State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}

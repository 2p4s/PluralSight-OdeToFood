using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Marc's Pizza", Cuisine=CuisineType.Italian},
                new Restaurant{Id=2, Name="Fonions", Cuisine=CuisineType.French},
                new Restaurant{Id=3, Name="YK Palace", Cuisine=CuisineType.Indian}

            };
        }

        public void Add(Restaurant restaurant)
        {
            //adds it to the in-memory list, should be a db really
            restaurants.Add(restaurant);
            //manually increment the id since we're not doing this in a database, but use linq to calculate the max number
            restaurant.Id = restaurants.Max(r => r.Id) + 1;


        }

        public Restaurant Get(int id)
        {
            //using linq, get the first or default restaurant (r) where id matches the incoming id
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}

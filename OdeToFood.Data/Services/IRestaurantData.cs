﻿using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    //define restaurant data interface
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        //get just a restaurant
        Restaurant Get(int id);


        void Add(Restaurant restaurant);
    }
}
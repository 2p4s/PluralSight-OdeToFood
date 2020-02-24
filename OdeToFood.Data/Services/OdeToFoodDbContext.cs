using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    //setup to derive from DbContext which is part of the Entity Framework class
    public class OdeToFoodDbContext : DbContext
    {
        //can be used to point to different db contexts, such as local vs live vs inmemory!
        //DbSet tells it what type of data we are dealing with, by default, the name will reference the table name
        //this definition can be used to create the db structure
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}

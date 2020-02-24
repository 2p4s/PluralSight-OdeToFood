using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]  //can add regular expressions or ranges in addition to required, also DisplayFormats(DataFormatString=...)
        [MaxLength(255)]
        public string Name { get; set; }
        //restrict cuising using enum
        [Display(Name="Type of Food")]
        public CuisineType Cuisine { get; set; }

     }
}

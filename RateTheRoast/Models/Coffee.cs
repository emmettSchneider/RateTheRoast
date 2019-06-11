using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    // Table Roaster {
  //  Id int[pk]
  //  Name varchar
  //  City varchar
  //  State char (2)
  //ImagePath varchar
//}
public class Coffee
    {
        [Key]
        public int RoasterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string ImagePath { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Roaster
    {
        [Key]
        public int RoasterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Roaster Logo")]
        public string ImagePath { get; set; }
    }
}


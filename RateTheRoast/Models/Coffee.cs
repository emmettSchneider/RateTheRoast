using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Coffee
    {
        [Key]
        public int CoffeeId { get; set; }

        [Required]
        public int RoasterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Origin { get; set; }

        public string Region { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int RoastIntensityId { get; set; }

        public string ImagePath { get; set; }

    }
}


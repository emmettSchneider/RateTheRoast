using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int USAstateId { get; set; }
        public USAstate USAstate { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ApplicationUser User { get; set; }

    }
}

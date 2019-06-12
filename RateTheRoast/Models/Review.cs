using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateEdited { get; set; }

        public int BrewMethodId { get; set; }

        public double Price { get; set; }

        public int? LocationId { get; set; }

        [Required]
        public string Narrative { get; set; }

        [Required]
        public int Score { get; set; }
        
        public ApplicationUser User { get; set; }

        public Coffee Coffee { get; set; }

        public Location Location { get; set; }

        public BrewMethod BrewMethod { get; set; }
    }
}


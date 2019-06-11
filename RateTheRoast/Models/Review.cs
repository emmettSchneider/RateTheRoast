using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Review
    {
        [Key]
        public int CoffeeId { get; set; }

        [Key]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateEdited { get; set; }

        [Key]
        public int BrewMethodId { get; set; }

        public double Price { get; set; }

        [Key]
        public int LocationId { get; set; }

        public string Narrative { get; set; }

        public int Score { get; set; }
    }
}

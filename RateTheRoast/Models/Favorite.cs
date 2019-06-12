using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int CoffeeId { get; set; }
        [Required]
        public Coffee Coffee { get; set; }
    }
}

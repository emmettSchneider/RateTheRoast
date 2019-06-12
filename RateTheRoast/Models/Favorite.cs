using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int CoffeeId { get; set; }
    }
}

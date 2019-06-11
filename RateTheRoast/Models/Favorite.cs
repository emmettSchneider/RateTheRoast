using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Favorite
    {
        [Key]
        public int UserId { get; set; }

        [Key]
        public int CoffeeId { get; set; }

        public virtual ICollection<Coffee> Coffees { get; set; }
    }
}

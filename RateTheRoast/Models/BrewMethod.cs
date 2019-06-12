using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class BrewMethod
    {
        [Key]
        public int BrewMethodId { get; set; }
        public string Method { get; set; }

    }
}


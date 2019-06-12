using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class RoastIntensity
    {
        [Key]
        public int RoastIntensityId { get; set; }
        public string Intensity { get; set; }
    }
}

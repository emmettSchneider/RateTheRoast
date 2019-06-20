using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class State
    {
        [Key]
        public string StateAbbrev { get; set; }
        public string StateName { get; set; }

        public ICollection<Roaster> Roasters { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

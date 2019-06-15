using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RateTheRoast.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        public string City { get; set; }
        [Required]
        public int USAstateId { get; set; }
        public USAstate USAstate { get; set; }
        [Required]
        public string Handle { get; set; }
        [Required]
        public string NormalizedHandle { get; set; }

        public Roaster Roaster { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

    }

}


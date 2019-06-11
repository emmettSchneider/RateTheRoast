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
        public string Username { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}

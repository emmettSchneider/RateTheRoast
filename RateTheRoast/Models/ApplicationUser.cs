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
        public string State { get; set; }

        public bool IsAdministrator { get; set; }

        public bool IsRoaster { get; set; }

    }
}


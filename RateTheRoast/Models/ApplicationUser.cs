using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using RateTheRoast.Models.ValidationModels;

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
        [CheckState(ValidState ="AK,AL,AR,AS,AZ,CA,CO,CT,DC,DE,FL,GA,HI,IA,ID,IL,IN,KS,KY,LA,MA,MD,ME,MI,MN,MO,MS,MT,NC,ND,NE,NH,NJ,NM,NV,NY,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VA,VT,WA,WI,WV,WY", ErrorMessage = "Please enter a valid USPS state abbreviation, e.g. AL, AK, AZ.")]
        public string StateAbbrev { get; set; }
        public State State { get; set; }
        [Required]
        public string Handle { get; set; }
        [Required]
        public string NormalizedHandle { get; set; }

        public Roaster Roaster { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }

    }

}


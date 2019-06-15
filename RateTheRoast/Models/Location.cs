using RateTheRoast.Models.ValidationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [CheckState(ValidState = "AK,AL,AR,AS,AZ,CA,CO,CT,DC,DE,FL,GA,HI,IA,ID,IL,IN,KS,KY,LA,MA,MD,ME,MI,MN,MO,MS,MT,NC,ND,NE,NH,NJ,NM,NV,NY,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VA,VT,WA,WI,WV,WY", ErrorMessage = "Please enter a valid USPS state abbreviation, e.g. AL, AK, AZ.")]
        public string StateAbbrev { get; set; }
        public State State { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ApplicationUser User { get; set; }

    }
}

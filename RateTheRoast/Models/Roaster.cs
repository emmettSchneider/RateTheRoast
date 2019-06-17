using RateTheRoast.Models.ValidationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Roaster
    {
        [Key]
        public int RoasterId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [CheckState(ValidState = "AK,AL,AR,AS,AZ,CA,CO,CT,DC,DE,FL,GA,HI,IA,ID,IL,IN,KS,KY,LA,MA,MD,ME,MI,MN,MO,MS,MT,NC,ND,NE,NH,NJ,NM,NV,NY,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VA,VT,WA,WI,WV,WY", ErrorMessage = "Please enter a valid USPS state abbreviation, e.g. AL, AK, AZ.")]
        public string StateAbbrev { get; set; }
        public State State { get; set; }

        [Display(Name = "Roaster Logo")]
        public string ImagePath { get; set; }
        public ICollection <Coffee> Coffees { get; set; }
    }
}


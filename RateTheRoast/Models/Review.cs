using RateTheRoast.Models.ValidationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateEdited { get; set; }

        public int BrewMethodId { get; set; }

        public double Price { get; set; }


        public string PurchaseAddress { get; set; }
        public string PurchaseCity { get; set; }

        [CheckState(ValidState = "AK,AL,AR,AS,AZ,CA,CO,CT,DC,DE,FL,GA,HI,IA,ID,IL,IN,KS,KY,LA,MA,MD,ME,MI,MN,MO,MS,MT,NC,ND,NE,NH,NJ,NM,NV,NY,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VA,VT,WA,WI,WV,WY", ErrorMessage = "Please enter a valid USPS state abbreviation, e.g. AL, AK, AZ.")]
        public string StateAbbrev { get; set; }
        public State State { get; set; }

        [Required]
        public string Narrative { get; set; }

        [Required]
        public int Score { get; set; }

        public Coffee Coffee { get; set; }

  

        public BrewMethod BrewMethod { get; set; }

        public ApplicationUser User { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RateTheRoast.Models.ValidationModels
{
    public sealed class CheckState : ValidationAttribute
    {
        public String ValidState { get; set; }
        protected override ValidationResult IsValid(object state, ValidationContext validationContext)
        {
            string[] myarr = ValidState.ToString().Split(',');
            if (myarr.Contains(state))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Please enter a valid USPS state abbreviation.");
            }
        }
    }
}
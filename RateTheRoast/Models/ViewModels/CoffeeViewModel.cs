using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateTheRoast.Models.ViewModels
{
    public class CoffeeViewModel
    {
        public Coffee Coffee { get; set; }
        public Review Review { get; set; }
    }
}

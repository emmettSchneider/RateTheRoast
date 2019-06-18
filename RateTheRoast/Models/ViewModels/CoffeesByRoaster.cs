using System.Collections.Generic;
using RateTheRoast.Models;
using RateTheRoast.Data;

namespace RateTheRoast.Models.ViewModels
{
    public class CoffeesByRoasterViewModel
    {
        public Roaster Roaster { get; set; }
        public IEnumerable<Coffee> Coffees { get; set; }

    }
}

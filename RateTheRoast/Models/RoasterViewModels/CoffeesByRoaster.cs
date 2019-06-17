using System.Collections.Generic;
using RateTheRoast.Models;
using RateTheRoast.Data;

namespace RateTheRoast.Models.RoasterViewModels
{
    public class CoffeesByRoaster
    {
        public Roaster Roaster { get; set; }
        public IEnumerable<Coffee> Coffees { get; set; }

    }
}

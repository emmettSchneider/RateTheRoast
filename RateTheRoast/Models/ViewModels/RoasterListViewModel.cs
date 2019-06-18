using System.Collections.Generic;
using RateTheRoast.Models;
using RateTheRoast.Data;

namespace RateTheRoast.Models.ViewModels
{
    public class RoasterListViewModel
    {
        public IEnumerable<Roaster> Roasters { get; set; }
    }
}

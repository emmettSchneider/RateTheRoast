using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateTheRoast.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}

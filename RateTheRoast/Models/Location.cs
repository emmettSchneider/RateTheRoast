using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateTheRoast.Models
{
//    Table Location
//    {
//        Id int [pk]
//        Name varchar
//        Address varchar
//        City varchar
//        State char(2)
//    }
    public class Location
    {
        public string Name { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }

        public string State { get; set; }

    }
}

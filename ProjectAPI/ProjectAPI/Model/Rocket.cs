using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Rocket
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int FlightNumber { get; set; }
        public bool Reusable { get; set; }
        public Organisation Organisation { get; set; }
        public Hypermedia Link { get; set; } //Een link naar afbeelding
    }
}

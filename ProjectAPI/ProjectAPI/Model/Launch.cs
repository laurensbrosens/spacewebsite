using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Launch
    {
        public int ID { get; set; }
        public DateTime LaunchDate { get; set; }
        public Rocket Rocket { get; set; }
        public Organisation Organisation { get; set; }
        public Location Location { get; set; }
        public Mission Mission { get; set; }
        public Hypermedia Link { get; set; } //Een link naar zichzelf
    }
}

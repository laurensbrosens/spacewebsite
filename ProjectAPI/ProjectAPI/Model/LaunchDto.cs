using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class LaunchDto
    {
        public int ID { get; set; }
        public Hypermedia Link { get; set; }
        public DateTime LaunchDate { get; set; }
        public string RocketType { get; set; }
        public string OrganisationName { get; set; }
        public string LocationName { get; set; }
        public string MissionDestination { get; set; }
    }
}

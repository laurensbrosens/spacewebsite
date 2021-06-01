using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class LaunchDetailDto
    {
        public int ID { get; set; }
        public DateTime LaunchDate { get; set; }
        public string RocketType { get; set; }
        public Hypermedia RocketLink { get; set; }
        public string OrganisationName { get; set; }
        public string LocationName { get; set; }
        public string LocationLaunchPad { get; set; }
        public string MissionDescription { get; set; }
        public string MissionCargo { get; set; }
        public bool? MissionSuccess { get; set; }
        public bool MissionCrewed { get; set; }
        public string MissionDestination { get; set; }

    }
}

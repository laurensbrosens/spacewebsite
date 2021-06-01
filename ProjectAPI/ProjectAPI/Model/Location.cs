using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Location
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string LaunchPad { get; set; }
        [JsonIgnore]
        public List<Launch> Launches { get; set; }
    }
}

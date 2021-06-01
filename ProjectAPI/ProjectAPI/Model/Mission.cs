using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Mission
    {
        public string Description { get; set; }
        public int ID { get; set; }
        public string Cargo { get; set; }
        public bool? Success { get; set; }
        public bool Crewed { get; set; }
        public string Destination { get; set; }
        public List<Organisation> Organisations { get; set; }
    }
}

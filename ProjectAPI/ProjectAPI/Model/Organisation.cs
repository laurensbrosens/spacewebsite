using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Model
{
    public class Organisation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Mission> Missions { get; set; }
    }
}

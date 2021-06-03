using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class DBInitializer
    {
        public static void Initialize(DBContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var testorganisation = new Organisation()
            {
                Name = "Roscosmos"
            };
            var testorganisation2 = new Organisation()
            {
                Name = "SpaceX"
            };
            var testrocket = new Rocket()
            {
                Type = "Soyuz",
                FlightNumber = 1681,
                Reusable = false,
                Organisation = testorganisation
            };
            var testrocket2 = new Rocket()
            {
                Type = "Falcon 9",
                FlightNumber = 116,
                Reusable = true,
                Organisation = testorganisation2
            };
            var testlocation = new Location()
            {
                LocationName = "Kazakhstan",
                LaunchPad = "Baikonur Cosmodrome"
            };
            var testlocation2 = new Location()
            {
                LocationName = "Cape Canaveral",
                LaunchPad = "LC-40"
            };
            var testmission = new Mission()
            {
                Crewed = true,
                Success = null,
                Description = "A Russian Soyuz rocket will launch the crewed Soyuz MS-18 spacecraft to the International Space Station with NASA astronaut Mark Vande Hei and two Russian cosmonauts, Oleg Novitsky and Pyotr Dubrov.",
                Cargo = "Crew",
                Destination = "ISS"
            };
            var testmission2 = new Mission()
            {
                Crewed = false,
                Success = null,
                Description = "29th Starlink mission",
                Cargo = "60 satellites",
                Destination = "orbit"
            };
            var testlaunch = new Launch()
            {
                LaunchDate = DateTime.Now,
                Rocket = testrocket,
                Location = testlocation,
                Organisation = testorganisation,
                Mission = testmission
            };
            var testlaunch2 = new Launch()
            {
                LaunchDate = DateTime.Now,
                Rocket = testrocket2,
                Location = testlocation2,
                Organisation = testorganisation2,
                Mission = testmission2

            };
            context.Launches.Add(testlaunch);
            context.Launches.Add(testlaunch2);
            context.SaveChanges();
            foreach (var launch in context.Launches)
            {
                launch.Link = new Hypermedia()
                {
                    href = @$"http://localhost:49774/api/v1/Launches/{launch.ID}",
                    method = "get"
                };
            }
            foreach (var rocket in context.Rockets)
            {
                if (rocket.Type == "Falcon 9")
                {
                    rocket.Link = new Hypermedia()
                    {
                        href = @$"https://upload.wikimedia.org/wikipedia/commons/5/5d/SpaceX_Falcon_9.jpg",
                        method = "get"
                    };
                }
                else if (rocket.Type == "Soyuz")
                {
                    rocket.Link = new Hypermedia()
                    {
                        href = @$"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Soyuz_TMA-9_launch.jpg/1200px-Soyuz_TMA-9_launch.jpg",
                        method = "get"
                    };
                }
            }
            context.SaveChanges();
        }
    }
}

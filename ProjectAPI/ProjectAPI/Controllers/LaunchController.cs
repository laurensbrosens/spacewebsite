using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/v1/Launches")]
    [ApiController]
    public class LaunchController : ControllerBase
    {
        [STAThread]
        static void Main()
        {
        }
        private readonly DBContext context;
        public LaunchController(DBContext myContext)
        {
            context = myContext;
        }
        /*
        [HttpGet]
        [Authorize]
        public IActionResult GetLaunches(int? page, int length = 2)
        {
            IEnumerable<Launch> launches = context.Launches.Include(d => d.Location).Include(d => d.Mission).Include(d => d.Organisation).Include(d => d.Rocket.Links).Include(d => d.Rocket).Include(d => d.Links);

            //Paging
            if (page.HasValue)
            {
                launches = launches.Skip(page.Value * length);
                launches = launches.Take(length);
            }
            return Ok(launches);
        }*/
        [HttpGet]
        //[Authorize] Enkel inloggen om de details te zien
        public IActionResult GetLaunches(int? page, int length = 2)
        {
            var launches = context.Launches.Include(d => d.Location).Include(d => d.Mission).Include(d => d.Organisation).Include(d => d.Rocket).Select(d =>
                new LaunchDto()
                {
                    ID = d.ID,
                    Link = d.Link,
                    LaunchDate = d.LaunchDate,
                    MissionDestination = d.Mission.Destination,
                    LocationName = d.Location.LocationName,
                    OrganisationName = d.Organisation.Name,
                    RocketType = d.Rocket.Type
                });
            //Paging
            if (page.HasValue)
            {
                launches = launches.Skip(page.Value * length);
                launches = launches.Take(length);
            }
            return Ok(launches);
        }

        [Route("{id}")]
        //[Authorize]
        [HttpGet]
        public IActionResult GetLaunch(int id)
        {
            var launch = context.Launches.Include(d => d.Location).Include(d => d.Mission).Include(d => d.Organisation).Include(d => d.Rocket).Select(d =>
                new LaunchDetailDto()
                {
                    ID = d.ID,
                    LaunchDate = d.LaunchDate,
                    MissionDestination = d.Mission.Destination,
                    LocationName = d.Location.LocationName,
                    OrganisationName = d.Organisation.Name,
                    RocketType = d.Rocket.Type,
                    MissionDescription = d.Mission.Description,
                    LocationLaunchPad = d.Location.LaunchPad,
                    MissionCargo = d.Mission.Cargo,
                    MissionCrewed = d.Mission.Crewed,
                    MissionSuccess = d.Mission.Success,
                    RocketLink = d.Rocket.Link
                }).SingleOrDefault(d => d.ID == id);
            if (launch == null)
            {
                return NotFound();
            }
            return Ok(launch);
        }

        /*
        [Route("{id}")]
        [Authorize]
        [HttpGet]
        public IActionResult GetLaunch(int id)
        {
            var launch = context.Launches.Include(d => d.Location).Include(d => d.Mission).Include(d => d.Organisation).Include(d => d.Rocket).SingleOrDefault(d => d.ID == id);
            if (launch == null)
            {
                return NotFound();
            }
            return Ok(launch);
        }*/
    }
}

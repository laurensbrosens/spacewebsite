using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/v2")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        [Route("Test")]
        public IActionResult GetTest()
        {
            return Ok("Het werkt");
        }
    }
}

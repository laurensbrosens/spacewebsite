using Microsoft.EntityFrameworkCore;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/v1/Organisations")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly DBContext context;
        public OrganisationController(DBContext myContext)
        {
            context = myContext;
        }
        [HttpGet]
        public IActionResult GetOrganisations()
        {
            var organisations = context.Organisations;
            return Ok("test");
        }

    }
}

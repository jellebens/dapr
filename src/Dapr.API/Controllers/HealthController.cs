using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.API.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController: ControllerBase
    {
        [HttpGet("live")]
        public IActionResult live() {
            return Ok();
        }

        [HttpGet("ready")]
        public IActionResult ready()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {

        public TestController()
        { }

        [Route("IsRunning")]
        public IActionResult IsRunning()
        {
            return Ok("yes, i am running.");
        }
    }
}

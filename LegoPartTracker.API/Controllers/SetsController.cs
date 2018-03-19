using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Controllers
{
    [Route("api/sets")]
    public class SetsController: Controller
    {
        [HttpGet()]
        public IActionResult GetSets()
        {
            return Ok(SetsDataStore.Current.Sets);
        }

        [HttpGet("{set_num}")]
        public IActionResult GetSet(string set_num)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.Set_num == set_num);
            if (setToReturn == null)
                return NotFound();

            return Ok(setToReturn);
        }
    }
}

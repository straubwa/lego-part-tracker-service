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
        public JsonResult GetSets()
        {
            return new JsonResult(SetsDataStore.Current.Sets);
        }

        [HttpGet("{set_num}")]
        public JsonResult GetSet(string set_num)
        {
            return new JsonResult(
                SetsDataStore.Current.Sets.FirstOrDefault(s => s.Set_num == set_num)
                );
        }
    }
}

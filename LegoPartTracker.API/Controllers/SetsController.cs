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

        [HttpGet("{setNumber}")]
        public IActionResult GetSet(string setNumber)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
                return NotFound();

            return Ok(setToReturn);
        }

        [HttpGet("{setNumber}/Parts")]
        public IActionResult GetSetParts(string setNumber)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
                return NotFound();

            return Ok(setToReturn.Parts);
        }

        [HttpGet("{setNumber}/Parts/{id}")]
        public IActionResult GetSetPart(string setNumber, int id)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
                return NotFound();

            var partToReturn = setToReturn.Parts.FirstOrDefault(p => p.Id == id);
            if (partToReturn == null)
                return NotFound();

            return Ok(partToReturn);
        }
    }
}

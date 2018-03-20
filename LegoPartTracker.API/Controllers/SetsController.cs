using LegoPartTracker.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Controllers
{
    [Route("api/sets")]
    public class SetsController: Controller
    {
        private ILogger<SetsController> _logger;

        public SetsController(ILogger<SetsController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetSets()
        {
            return Ok(SetsDataStore.Current.Sets);
        }

        [HttpGet("{setNumber}", Name = "GetSet")]
        public IActionResult GetSet(string setNumber)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            return Ok(setToReturn);
        }

        [HttpPost()]
        public IActionResult CreateSet([FromBody] SetDto set)
        {
            if(set == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SetsDataStore.Current.Sets.Add(set);

            return CreatedAtRoute("GetSet", new { setNumber = set.SetNumber }, set);
        }


        [HttpGet("{setNumber}/Parts")]
        public IActionResult GetSetParts(string setNumber)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            return Ok(setToReturn.Parts);
        }

        [HttpGet("{setNumber}/Parts/{id}")]
        public IActionResult GetSetPart(string setNumber, int id)
        {
            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var partToReturn = setToReturn.Parts.FirstOrDefault(p => p.Id == id);
            if (partToReturn == null)
                return NotFound();

            return Ok(partToReturn);
        }


        [HttpPatch("{setNumber}/Parts/{id}")]
        public IActionResult PartiallyUpdateSetPart(string setNumber, int id, [FromBody] JsonPatchDocument<PartDto> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var setToReturn = SetsDataStore.Current.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (setToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var partToUpdate = setToReturn.Parts.FirstOrDefault(p => p.Id == id);
            if (partToUpdate == null)
                return NotFound();

            patchDocument.ApplyTo(partToUpdate, ModelState);

            TryValidateModel(partToUpdate);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }
    }
}

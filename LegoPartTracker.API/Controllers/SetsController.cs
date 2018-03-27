using AutoMapper;
using LegoPartTracker.API.Models;
using LegoPartTracker.API.Services;
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
        private ISetInfoRepository _setInfoRepository;

        public SetsController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository)
        {
            _logger = logger;
            _setInfoRepository = setInfoRepository;
        }


        [HttpGet()]
        public IActionResult GetSets()
        {
            var setEntities = _setInfoRepository.GetSets();

            var results = Mapper.Map<IEnumerable<SetDto>>(setEntities);
            return Ok(results);
        }


        [HttpGet("{setNumber}", Name = "GetSet")]
        public IActionResult GetSet(string setNumber)
        {
            var setToReturn = _setInfoRepository.GetSet(setNumber);
            if (setToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var results = Mapper.Map<SetDto>(setToReturn);
            return Ok(setToReturn);
        }
        

        [HttpGet("{setNumber}/Parts")]
        public IActionResult GetSetParts(string setNumber)
        {
            if (!_setInfoRepository.SetExists(setNumber))
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var setPartsToReturn = _setInfoRepository.GetSetParts(setNumber);

            var results = Mapper.Map<IEnumerable<SetPartDto>>(setPartsToReturn);
            return Ok(results);
        }


        [HttpGet("{setNumber}/Parts/{id}")]
        public IActionResult GetSetPart(string setNumber, int id)
        {
            if (!_setInfoRepository.SetExists(setNumber))
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var setPartToReturn = _setInfoRepository.GetSetPart(setNumber, id);
            if (setPartToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} Part {id} not found");
                return NotFound();
            }

            var results = Mapper.Map<SetPartDto>(setPartToReturn);
            return Ok(results);
        }


        [HttpDelete("{setNumber}")]
        public IActionResult DeleteSet(string setNumber)
        {
            if (!_setInfoRepository.SetExists(setNumber))
            {
                _logger.LogInformation($"Set Number {setNumber} not found to delete");
                return NotFound();
            }

            _setInfoRepository.RemoveSet(setNumber);
            _setInfoRepository.Save();
            return NoContent();
        }


        [HttpPatch("{setNumber}/Parts/{id}")]
        public IActionResult UpdateSetPart(string setNumber, int id, [FromBody] JsonPatchDocument<SetPartForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            if (!_setInfoRepository.SetExists(setNumber))
            {
                _logger.LogInformation($"Set Number {setNumber} not found");
                return NotFound();
            }

            var setPartToReturn = _setInfoRepository.GetSetPart(setNumber, id);
            if (setPartToReturn == null)
            {
                _logger.LogInformation($"Set Number {setNumber} Part {id} not found");
                return NotFound();
            }

            var setPartToPatch = Mapper.Map<SetPartForUpdateDto>(setPartToReturn);

            patchDocument.ApplyTo(setPartToPatch, ModelState);

            TryValidateModel(setPartToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Set Number {setNumber} Part {id} patch was incorrectly formatted");
                return BadRequest(ModelState);
            }

            Mapper.Map(setPartToPatch, setPartToReturn);

            if(!_setInfoRepository.Save())
            {
                _logger.LogError($"Set Number {setNumber} Part {id} patch error when saving");
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }
    }
}

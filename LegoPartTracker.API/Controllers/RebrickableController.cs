using LegoPartTracker.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Controllers
{
    [Route("api/Rebrickable")]
    public class RebrickableController : Controller
    {
        private ILogger<SetsController> _logger;
        private ISetInfoRepository _setInfoRepository;
        private IRebrickableInfoRepository _rebrickableInfoRepository;
        
        public RebrickableController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository, IRebrickableInfoRepository rebrickableInfoRepository)
        {
            _logger = logger;
            _setInfoRepository = setInfoRepository;
            _rebrickableInfoRepository = rebrickableInfoRepository;

        }

        [HttpGet("Sets/{setNumber}")]
        public IActionResult GetRebrickableSet(string setNumber)
        {
            var set = _rebrickableInfoRepository.GetSet(setNumber);

            return Ok(set);
        }

        [HttpGet("Sets/{setNumber}/Parts")]
        public IActionResult GetRebrickableSetParts(string setNumber)
        {
            var setParts = _rebrickableInfoRepository.GetSetParts(setNumber);

            return Ok(setParts);
        }

        [HttpGet("Themes")]
        public IActionResult GetThemes()
        {
            var themes = _rebrickableInfoRepository.GetAllThemes();

            return Ok(themes);
        }

        [HttpGet("PartCategories")]
        public IActionResult GetPartCategories()
        {
            var partCategories = _rebrickableInfoRepository.GetAllPartCategories();

            return Ok(partCategories);
        }
        
    }
}
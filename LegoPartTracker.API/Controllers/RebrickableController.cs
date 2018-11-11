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

        [HttpGet("Themes/{id}")]
        public IActionResult GetTheme(int id)
        {
            var theme = _rebrickableInfoRepository.GetTheme(id);

            return Ok(theme);
        }

        [HttpGet("PartCategories")]
        public IActionResult GetPartCategories()
        {
            var partCategories = _rebrickableInfoRepository.GetAllPartCategories();

            return Ok(partCategories);
        }
        
        [HttpPost("Sets/ImportSet/{setNumber}")]
        public IActionResult ImportRebrickableSet(string setNumber)
        {
            //get set from rebrickable
            //confirm that it does not exist in our database
            //create new set in our db (mapping)
            //include all parts

            if (_setInfoRepository.SetExists(setNumber))
                return BadRequest($"setNumber {setNumber} already exists");

            var sourceSet = _rebrickableInfoRepository.GetSet(setNumber);

            if (sourceSet == null)
                return NotFound();

            var s = new Entities.Set()
            {
                SetNumber = sourceSet.SetNumber,
                Name = sourceSet.Name,
                ThemeId = sourceSet.ThemeId,
                Theme = GetThemePath(sourceSet.ThemeId),
                SetImageUrl = sourceSet.SetImageUrl.AbsoluteUri
            };

            var sourceSetParts = _rebrickableInfoRepository.GetSetParts(setNumber);

            foreach(var sourceSetPart in sourceSetParts)
            {
                var sp = new Entities.SetPart()
                {
                    Id = sourceSetPart.Id,
                    PartNumber = sourceSetPart.Part.PartNum,
                    Name = sourceSetPart.Part.Name,
                    PartUrl = sourceSetPart.Part.PartUrl,
                    PartImageUrl = sourceSetPart.Part.PartImgUrl,
                    Color = sourceSetPart.Color.Name,
                    QuantityNeeded = sourceSetPart.Quantity,
                    ElementId = sourceSetPart.ElementId
                };

                s.Parts.Add(sp);
            }

            _setInfoRepository.AddSet(s);
            _setInfoRepository.Save();

            return NoContent();
        }

        private string GetThemePath(int themeId)
        {
            var theme = _rebrickableInfoRepository.GetTheme(themeId);
            
            string themePath = theme.Name;
            int i = 1;

            while(theme.ParentId.HasValue && i<10)
            {
                theme = _rebrickableInfoRepository.GetTheme(theme.ParentId.Value);
                themePath = theme.Name + " > " + themePath;
                i++;
            }

            return themePath;
        }
    }
}
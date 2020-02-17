using AutoMapper;
using LegoPartTracker.API.Models;
using LegoPartTracker.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Controllers
{
    [Route("api/parts")]
    public class PartsController : Controller
    {
        private ILogger<SetsController> _logger;
        private ISetInfoRepository _setInfoRepository;
        private IConfiguration _config;

        public PartsController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository, IConfiguration config)
        {
            _logger = logger;
            _setInfoRepository = setInfoRepository;
            _config = config;
        }

        [HttpGet("ImageUploadUrl")]
        public IActionResult GetImageUploadUrl()
        {
            //doing this to hide the upload api key
            return Ok("{\"url\":\"https://api.imgbb.com/1/upload?key=" + _config["imgbb:key"] + "\"}");
        }

        public PartsController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository)
        {
            _logger = logger;
            _setInfoRepository = setInfoRepository;
        }

        [HttpGet("PartsWithoutGroup/Categories")]
        public IActionResult GetCategoriesWithoutAssignedGroup()
        {
            var partsWithoutGroup = _setInfoRepository.GetPartGroupDetailsWithoutGroup();

            var a = partsWithoutGroup
                .GroupBy(g => new { g.CategoryId, g.CategoryName })
                .Select(g => new { Id = g.Key.CategoryId, Name = g.Key.CategoryName, PartCount = g.Count() });

            return Ok(a);
        }

        [HttpGet("PartsWithoutGroup/{categoryId}")]
        public IActionResult GetPartsWithoutGroup(int categoryId)
        {
            var parts = _setInfoRepository.GetPartGroupDetailsWithoutGroup(categoryId).OrderBy(o => o.Name);
            return Ok(parts);
        }

        [HttpPost("PartGroup")]
        public IActionResult NewPartGroup([FromBody] PartGroupForCreateDto partGroup)
        {
            var pg = new Entities.PartGroup()
            {
                PartNumber = partGroup.PartNumber,
                GroupId = partGroup.GroupId,
                CreatedDate = DateTime.Now
            };

            _setInfoRepository.AddPartGroup(pg);
            _setInfoRepository.Save();

            return Ok(pg);
        }


        [HttpGet("Groups")]
        public IActionResult GetGroups()
        {
            var groups = _setInfoRepository.GetGroups().OrderBy(o => o.Name);

            return Ok(groups);
        }
        
        [HttpGet("Groups/{groupId}/Parts")]
        public IActionResult GetPartsByGroup(int groupId)
        {
            var parts = _setInfoRepository.GetPartGroupDetailsByGroup(groupId).OrderBy(o => o.Name);
            
            return Ok(parts);
        }

        [HttpPost("Groups/{groupId}/Subgroups")]
        public IActionResult NewSubgroup(int groupId, [FromBody] SubgroupForCreateDto subGroup)
        {
            var sg = new Entities.Subgroup()
            {
                Name = subGroup.Name,
                GroupId = groupId,
                IconUrl = subGroup.IconUrl,
                IconFileName = subGroup.IconFileName,
                CreatedDate = DateTime.Now
            };

            _setInfoRepository.AddSubgroup(sg);
            _setInfoRepository.Save();

            return Ok(sg);
        }

        [HttpGet("Groups/{groupId}/Subgroups")]
        public IActionResult GetSubgroups(int groupId)
        {
            var sg = _setInfoRepository.GetSubgroups(groupId);

            return Ok(sg);
        }

        [HttpGet("Groups/{groupId}/Subgroups/{subgroupId}/Parts")]
        public IActionResult GetPartsBySubgroup(int groupId, int subgroupId)
        {
            var parts = _setInfoRepository.GetPartGroupDetailsBySubgroup(subgroupId).OrderBy(o => o.Name);

            return Ok(parts);
        }

        [HttpPost("Groups/{groupId}/Subgroups/{subgroupId}/Parts")]
        public IActionResult NewPartSubgroup(int groupId, int subgroupId, [FromBody] PartNumberDto part)
        {
            var psg = new Entities.PartSubgroup()
            {
                PartNumber = part.PartNumber,
                SubgroupId = subgroupId,
                CreatedDate = DateTime.Now
            };
            _setInfoRepository.AddPartSubgroup(psg);
            _setInfoRepository.Save();
            return Ok(psg);
        }

        [HttpDelete("Groups/{groupId}/Subgroups/{subgroupId}/Parts")]
        public IActionResult RemovePartSubgroup(int groupId, int subgroupId, [FromBody] PartNumberDto part)
        {
            var psg = new Entities.PartSubgroup()
            {
                PartNumber = part.PartNumber,
                SubgroupId = subgroupId
            };

            _setInfoRepository.RemovePartSubgroup(psg);
            _setInfoRepository.Save();
            return Ok();
        }
    }
}
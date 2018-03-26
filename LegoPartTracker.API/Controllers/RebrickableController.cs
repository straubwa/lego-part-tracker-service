using LegoPartTracker.API.Entities;
using LegoPartTracker.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
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
        private IConfiguration _config;
        private ISetInfoRepository _setInfoRepository;

        public RebrickableController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _setInfoRepository = setInfoRepository;
        }

        [HttpGet("{setNumber}/Parts")]
        public void GetRebrickableSetParts(string setNumber)
        {
            RestClient client = new RestClient("https://rebrickable.com/api/v3/");
            RestRequest request = new RestRequest($"lego/sets/{ setNumber }/parts", Method.GET);
            request.AddHeader("authorization", "key " + _config["rebrickable:key"]);
            
            var response = client.Execute<Entities.Rebrickable.SetPartsResponse>(request);
            var setPartsResponse = response.Data;
        }
    }
}
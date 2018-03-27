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
        private IRestClient _rebrickableClient;

        public RebrickableController(ILogger<SetsController> logger, ISetInfoRepository setInfoRepository, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _setInfoRepository = setInfoRepository;

            //this should probably be moved to Startup and be injected
            _rebrickableClient = new RestClient("https://rebrickable.com/api/v3/");
            _rebrickableClient.AddDefaultHeader("authorization", "key " + _config["rebrickable:key"]);
        }

        [HttpGet("Sets/{setNumber}")]
        public IActionResult GetRebrickableSet(string setNumber)
        {
            RestRequest request = new RestRequest($"lego/sets/{ setNumber }", Method.GET);
            var response = _rebrickableClient.Execute<Entities.Rebrickable.Set>(request);
            var set = response.Data;

            return Ok(set);
        }

        [HttpGet("Sets/{setNumber}/Parts")]
        public IActionResult GetRebrickableSetParts(string setNumber)
        {
            RestRequest request = new RestRequest($"lego/sets/{ setNumber }/parts", Method.GET);
            List<Entities.Rebrickable.SetPart> setParts = GetAllSetPartsFromRebrickable(ref request);

            return Ok(setParts);
        }

        [HttpGet("Themes")]
        public IActionResult GetThemes()
        {
            RestRequest request = new RestRequest($"lego/themes", Method.GET);
            List<Entities.Rebrickable.Theme> themes = GetAllThemesFromRebrickable(ref request);

            return Ok(themes);
        }

        [HttpGet("PartCategories")]
        public IActionResult GetPartCategories()
        {
            RestRequest request = new RestRequest($"lego/part_categories", Method.GET);
            List<Entities.Rebrickable.PartCategory> partCategories = GetAllPartCategoriesFromRebrickable(ref request);

            return Ok(partCategories);
        }


        #region i'm sure these can be genericized, but just don't have the time / effort to do that for just a few needed calls.

        private List<Entities.Rebrickable.Theme> GetAllThemesFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.ThemeResponse>(request);
            var responseData = response.Data;

            List<Entities.Rebrickable.Theme> listToReturn = new List<Entities.Rebrickable.Theme>();
            listToReturn.AddRange(response.Data.Themes);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.ThemeResponse>(request);
                listToReturn.AddRange(response.Data.Themes);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        private List<Entities.Rebrickable.SetPart> GetAllSetPartsFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.SetPartResponse>(request);
            var responseData = response.Data;

            List<Entities.Rebrickable.SetPart> listToReturn = new List<Entities.Rebrickable.SetPart>();
            listToReturn.AddRange(response.Data.SetParts);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.SetPartResponse>(request);
                listToReturn.AddRange(response.Data.SetParts);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        private List<Entities.Rebrickable.PartCategory> GetAllPartCategoriesFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.PartCategoryResponse>(request);
            var responseData = response.Data;

            List<Entities.Rebrickable.PartCategory> listToReturn = new List<Entities.Rebrickable.PartCategory>();
            listToReturn.AddRange(response.Data.PartCategories);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.PartCategoryResponse>(request);
                listToReturn.AddRange(response.Data.PartCategories);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        #endregion
    }
}
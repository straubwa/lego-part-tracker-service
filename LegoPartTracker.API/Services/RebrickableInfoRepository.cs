using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Services
{
    public class RebrickableInfoRepository : IRebrickableInfoRepository
    {
        private IRestClient _rebrickableClient;

        public RebrickableInfoRepository(IConfiguration config)
        {
            _rebrickableClient = new RestClient("https://rebrickable.com/api/v3/");
            _rebrickableClient.AddDefaultParameter(new Parameter("key", config["rebrickable:key"], ParameterType.QueryString));
        }


        public Entities.Rebrickable.Set GetSet(string setNumber)
        {
            RestRequest request = new RestRequest($"lego/sets/{ setNumber }", Method.GET);
            var response = _rebrickableClient.Execute<Entities.Rebrickable.Set>(request);
            CheckResponse(response);

            return response.Data;
        }


        public List<Entities.Rebrickable.SetPart> GetSetParts(string setNumber)
        {
            RestRequest request = new RestRequest($"lego/sets/{ setNumber }/parts", Method.GET);
            List<Entities.Rebrickable.SetPart> setParts = GetAllSetPartsFromRebrickable(ref request);

            return setParts;
        }


        public Entities.Rebrickable.Theme GetTheme(int id)
        {
            RestRequest request = new RestRequest($"lego/themes/{ id }", Method.GET);
            var response = _rebrickableClient.Execute<Entities.Rebrickable.Theme>(request);
            CheckResponse(response);

            return response.Data;
        }


        public List<Entities.Rebrickable.Theme> GetAllThemes()
        {
            RestRequest request = new RestRequest($"lego/themes", Method.GET);
            List<Entities.Rebrickable.Theme> themes = GetAllThemesFromRebrickable(ref request);

            return themes;
        }


        public List<Entities.Rebrickable.PartCategory> GetAllPartCategories()
        {
            RestRequest request = new RestRequest($"lego/part_categories", Method.GET);
            List<Entities.Rebrickable.PartCategory> partCategories = GetAllPartCategoriesFromRebrickable(ref request);

            return partCategories;
        }

        private void CheckResponse(IRestResponse response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ApplicationException($"Bad Request: { response.StatusCode }, Content={ response.Content }");
            }
        }


        #region i'm sure these can be genericized, but just don't have the time / effort to do that for just a few needed calls.

        private List<Entities.Rebrickable.Theme> GetAllThemesFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.ThemeResponse>(request);
            CheckResponse(response);

            var responseData = response.Data;

            List<Entities.Rebrickable.Theme> listToReturn = new List<Entities.Rebrickable.Theme>();
            listToReturn.AddRange(response.Data.Themes);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.ThemeResponse>(request);
                CheckResponse(response);

                listToReturn.AddRange(response.Data.Themes);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        private List<Entities.Rebrickable.SetPart> GetAllSetPartsFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.SetPartResponse>(request);
            CheckResponse(response);

            var responseData = response.Data;

            List<Entities.Rebrickable.SetPart> listToReturn = new List<Entities.Rebrickable.SetPart>();
            listToReturn.AddRange(response.Data.SetParts);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.SetPartResponse>(request);
                CheckResponse(response);

                listToReturn.AddRange(response.Data.SetParts);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        private List<Entities.Rebrickable.PartCategory> GetAllPartCategoriesFromRebrickable(ref RestRequest request)
        {
            var response = _rebrickableClient.Execute<Entities.Rebrickable.PartCategoryResponse>(request);
            CheckResponse(response);

            var responseData = response.Data;

            List<Entities.Rebrickable.PartCategory> listToReturn = new List<Entities.Rebrickable.PartCategory>();
            listToReturn.AddRange(response.Data.PartCategories);

            bool getMore = (response.Data.Next != null);

            while (getMore)
            {
                request = new RestRequest(response.Data.Next.AbsoluteUri, Method.GET);
                response = _rebrickableClient.Execute<Entities.Rebrickable.PartCategoryResponse>(request);
                CheckResponse(response);

                listToReturn.AddRange(response.Data.PartCategories);
                getMore = (response.Data.Next != null);
            }

            return listToReturn;
        }

        #endregion
    }
}

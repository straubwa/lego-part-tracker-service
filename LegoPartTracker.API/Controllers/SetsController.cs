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
            return new JsonResult(new List<object>()
            {
                new {
                set_num = "70612-1",
                name = "Green Ninja Mech Dragon",
                theme_id = 616,
                theme = "Ninjago > Ninjago The Movie",
                set_img_url = "https://m.rebrickable.com/media/sets/70612-1.jpg"},

                new {
                set_num = "70614-1",
                name = "Lightning Jet",
                theme_id = 616,
                theme = "Ninjago > Ninjago The Movie",
                set_img_url = "https://m.rebrickable.com/media/sets/70614-1.jpg"},

                new {
                set_num = "70608-1",
                name = "Master Falls",
                theme_id = 616,
                theme = "Ninjago > Ninjago The Movie",
                set_img_url = "https://m.rebrickable.com/media/sets/70608-1.jpg"},

                new {
                set_num = "70611-1",
                name = "Water Strider",
                theme_id = 616,
                theme = "Ninjago > Ninjago The Movie",
                set_img_url = "https://m.rebrickable.com/media/sets/70611-1.jpg"},

                new {
                set_num = "70656-1",
                name = "garmadon, Garmadon, GARMADON!",
                theme_id = 435,
                theme = "Ninjago",
                set_img_url = "https://m.rebrickable.com/media/sets/70656-1.jpg"}
            });
        }
    }
}

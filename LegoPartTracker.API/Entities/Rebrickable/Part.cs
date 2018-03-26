using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class Part
    {
        [DeserializeAs(Name = "part_num")]
        public string PartNum { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "part_cat_id")]
        public int PartCatId { get; set; }

        [DeserializeAs(Name = "part_url")]
        public string PartUrl { get; set; }

        [DeserializeAs(Name = "part_img_url")]
        public string PartImgUrl { get; set; }
    }
}

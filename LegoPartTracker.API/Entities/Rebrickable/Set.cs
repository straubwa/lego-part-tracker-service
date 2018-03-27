using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class Set
    {
        [DeserializeAs(Name = "set_num")]
        public string SetNumber { get; set; }
        
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "year")]
        public int Year { get; set; }
        
        [DeserializeAs(Name = "theme_id")]
        public int ThemeId { get; set; }

        [DeserializeAs(Name = "num_parts")]
        public int NumberOfParts { get; set; }

        [DeserializeAs(Name = "set_img_url")]
        public Uri SetImageUrl { get; set; }

        [DeserializeAs(Name = "set_url")]
        public Uri SetUrl { get; set; }
    }
}

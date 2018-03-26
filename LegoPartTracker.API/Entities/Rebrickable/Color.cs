using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class Color
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "rgb")]
        public string Rgb { get; set; }

        [DeserializeAs(Name = "is_trans")]
        public bool IsTrans { get; set; }
    }
}

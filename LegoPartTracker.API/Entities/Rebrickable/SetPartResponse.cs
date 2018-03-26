using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class SetPartResponse
    {
        [DeserializeAs(Name = "count")]
        public int Count { get; set; }

        [DeserializeAs(Name = "next")]
        public Uri Next { get; set; }

        [DeserializeAs(Name = "previous")]
        public Uri Previous { get; set; }

        [DeserializeAs(Name = "results")]
        public List<SetPart> SetParts { get; set; }
    }
}

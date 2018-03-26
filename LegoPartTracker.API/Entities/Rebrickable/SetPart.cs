using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class SetPart
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "inv_part_id")]
        public int InvPartId { get; set; }

        [DeserializeAs(Name = "part")]
        public Part Part { get; set; }

        [DeserializeAs(Name = "color")]
        public Color Color { get; set; }
        
        [DeserializeAs(Name = "quantity")]
        public int Quantity { get; set; }

        [DeserializeAs(Name = "is_spare")]
        public bool IsSpare { get; set; }

        [DeserializeAs(Name = "element_id")]
        public string ElementId { get; set; }
    }
}

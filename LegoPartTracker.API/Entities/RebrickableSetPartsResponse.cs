using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{

    public class SetPartsResponse
    {
        [DeserializeAs(Name = "count")]
        public long Count { get; set; }

        [DeserializeAs(Name = "next")]
        public object Next { get; set; }

        [DeserializeAs(Name = "previous")]
        public object Previous { get; set; }

        [DeserializeAs(Name = "results")]
        public List<SetPart> Results { get; set; }
    }


    public class SetPart
    {
        [DeserializeAs(Name = "id")]
        public long Id { get; set; }

        [DeserializeAs(Name = "inv_part_id")]
        public long InvPartId { get; set; }

        [DeserializeAs(Name = "part")]
        public List<Part> Part { get; set; }

        [DeserializeAs(Name = "color")]
        public List<Color> Color { get; set; }
        
        [DeserializeAs(Name = "quantity")]
        public long Quantity { get; set; }

        [DeserializeAs(Name = "is_spare")]
        public bool IsSpare { get; set; }

        [DeserializeAs(Name = "element_id")]
        public string ElementId { get; set; }
    }


    public class Color
    {
        [DeserializeAs(Name = "id")]
        public long Id { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "rgb")]
        public string Rgb { get; set; }

        [DeserializeAs(Name = "is_trans")]
        public bool IsTrans { get; set; }
    }


    public class Part
    {
        [DeserializeAs(Name = "part_num")]
        public string PartNum { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "part_cat_id")]
        public long PartCatId { get; set; }

        [DeserializeAs(Name = "part_url")]
        public string PartUrl { get; set; }

        [DeserializeAs(Name = "part_img_url")]
        public string PartImgUrl { get; set; }
    }

}

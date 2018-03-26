using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class PartCategoryResponse
    {
        [DeserializeAs(Name = "count")]
        public int Count { get; set; }

        [DeserializeAs(Name = "next")]
        public Uri Next { get; set; }

        [DeserializeAs(Name = "previous")]
        public Uri Previous { get; set; }

        [DeserializeAs(Name = "results")]
        public List<PartCategory> PartCategories { get; set; }
    }
}

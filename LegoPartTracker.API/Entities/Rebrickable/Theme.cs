using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class Theme
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}

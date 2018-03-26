using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace LegoPartTracker.API.Entities.Rebrickable
{
    public class PartCategory
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    public class Subgroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

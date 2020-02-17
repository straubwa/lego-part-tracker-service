using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SubgroupForCreateDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string IconFileName { get; set; }
    }
}

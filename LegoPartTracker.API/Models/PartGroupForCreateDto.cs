using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class PartGroupForCreateDto
    {
        public string PartNumber { get; set; }

        public int GroupId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SetDto
    {
        public string Set_num { get; set; }
        public string Name { get; set; }
        public int Theme_id { get; set; }
        public string Theme { get; set; }
        public string Set_img_url { get; set; }
    }
}

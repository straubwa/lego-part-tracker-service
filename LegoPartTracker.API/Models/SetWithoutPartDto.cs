using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SetWithoutPartDto
    {
        public string SetNumber { get; set; }

        public string Name { get; set; }

        public int ThemeId { get; set; }

        public string Theme { get; set; }

        public string SetImageUrl { get; set; }
    }
}

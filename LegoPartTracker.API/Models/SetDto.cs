using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SetDto
    {
        public string SetNumber { get; set; }
        public string Name { get; set; }
        public int ThemeId { get; set; }
        public string Theme { get; set; }
        public string SetImageUrl { get; set; }

        public int NumberOfParts {  get
            {
                return Parts.Count;
            }
        }

        public ICollection<PartDto> Parts { get; set; } = new List<PartDto>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SetDto
    {
        [Required]
        public string SetNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public int ThemeId { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public string SetImageUrl { get; set; }

        public int NumberOfParts {  get
            {
                return Parts.Count;
            }
        }

        public ICollection<PartDto> Parts { get; set; } = new List<PartDto>();
    }
}

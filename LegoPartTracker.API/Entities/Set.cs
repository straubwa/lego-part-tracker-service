using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    public class Set
    {
        [Key]
        [Required]
        [MaxLength(100)]
        public string SetNumber { get; set; }

        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        public int ThemeId { get; set; }

        [Required]
        [MaxLength(400)]
        public string Theme { get; set; }

        [Required]
        [MaxLength(400)]
        public string SetImageUrl { get; set; }

        public ICollection<SetPart> Parts { get; set; } = new List<SetPart>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    [Table("SetDetail")]
    public class SetDetail
    {
        [Key]
        public string SetNumber { get; set; }
        public string Name { get; set; }
        public int ThemeId { get; set; }
        public string Theme { get; set; }
        public string SetImageUrl { get; set; }
        public int PartsNeeded { get; }
        public int PartsFound { get; }
    }
}

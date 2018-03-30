using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    public class SetPart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PartNumber { get; set; }

        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string PartUrl { get; set; }

        [MaxLength(400)]
        public string PartImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Color { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityNeeded { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityFound { get; set; }

        [MaxLength(100)]
        public string ElementId { get; set; }

        [ForeignKey("SetNumber")]
        public Set Set { get; set; }

        [MaxLength(100)]
        public string SetNumber { get; set; }
    }
}

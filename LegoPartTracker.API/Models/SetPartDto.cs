using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Models
{
    public class SetPartDto
    {
        public int Id { get; set; }

        public string PartNumber { get; set; }

        public string Name { get; set; }

        public string PartUrl { get; set; }

        public string PartImageUrl { get; set; }

        public string Color { get; set; }

        public int QuantityNeeded { get; set; }

        public int QuantityFound { get; set; }

        public int QuantityRemaining { get; set; }

        public DateTime? QuantityFoundDateChanged { get; set; }

        public string ElementId { get; set; }
    }
}


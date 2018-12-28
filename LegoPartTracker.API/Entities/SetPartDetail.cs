using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    [Table("PartDetail")]
    public class SetPartDetail
    {
        [Key]
        public int Id { get; set; }
        public string SetNumber { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string PartUrl { get; set; }
        public string PartImageUrl { get; set; }
        public string Color { get; set; }
        public int QuantityNeeded { get; set; }
        public int QuantityFound { get; set; }
        public DateTime? QuantityFoundDateChanged { get; set; }
        public string ElementId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }

        public int QuantityRemaining {
            get {
                return QuantityNeeded - QuantityFound;
            }
        }
    }
}

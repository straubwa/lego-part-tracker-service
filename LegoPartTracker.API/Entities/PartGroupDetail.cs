using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoPartTracker.API.Entities
{
    [Table("PartGroupDetail")]
    public class PartGroupDetail
    {
        [Key]
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string PartImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
    }
}

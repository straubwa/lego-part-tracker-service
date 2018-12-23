using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoPartTracker.API.Entities
{
    [Table("PartGroup")]
    public class PartGroup
    {
        [Key]
        public string PartNumber { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

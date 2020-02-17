using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoPartTracker.API.Entities
{
    [Table("Subgroup")]
    public class Subgroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string IconFileName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

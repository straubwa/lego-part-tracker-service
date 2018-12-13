using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API.Entities
{
    public class SetInfoContext : DbContext
    {
        public SetInfoContext(DbContextOptions<SetInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Set> Sets { get; set; }
        public DbQuery<SetDetail> SetDetails { get; set; }
        public DbSet<SetPart> Parts { get; set; }
        public DbQuery<SetPartDetail> PartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbQuery<PartGroup> PartGroups { get; set; }
        public DbQuery<PartGroupDetail> PartGroupDetails { get; set; }
        
    }
}

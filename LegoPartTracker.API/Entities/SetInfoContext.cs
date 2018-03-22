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
        public DbSet<SetPart> Parts { get; set; }

    }
}

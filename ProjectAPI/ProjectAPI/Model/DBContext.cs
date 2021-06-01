using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Model
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Launch> Launches { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Mission> Missions { get; set; }

    }
}

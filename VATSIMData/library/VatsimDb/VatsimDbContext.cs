using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimData;

/**
 * The Entity Framework Core tutorial is helpful here: 
 * https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
 *
 * You get this via this command: dotnet add package Microsoft.EntityFrameworkCore.Sqlite
 */

namespace VatsimLibrary.VatsimDb
{

    public class VatsimDbContext : DbContext
    {

        private string dbfile;

        public DbSet<VatsimClientPilot> Pilots { get; set; }
        public DbSet<VatsimClientPlannedFlight> Flights { get; set; }
        public DbSet<VatsimClientPilotSnapshot> Positions { get; set; }
        public DbSet<VatsimClientATC> Controllers { get; set; }

        public VatsimDbContext()
        {
            VatsimDataReader.EnsureDataDirectoryExists(VatsimDbHepler.DATA_DIR);
            this.dbfile = $@"{VatsimDbHepler.DATA_DIR}\vatsim.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($@"Data Source={dbfile}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // establish derived type keys
            modelBuilder.Entity<VatsimClientATC>()
                .HasKey(c => new { c.Cid, c.Callsign, c.TimeLogon });
            
            modelBuilder.Entity<VatsimClientPilot>()
                .HasKey(p => new { p.Cid, p.Callsign, p.TimeLogon });

            /* this establishes a composite key */
            modelBuilder.Entity<VatsimClientPlannedFlight>()
                .HasKey(f => new { f.Cid, 
                                   f.Callsign, 
                                   f.TimeLogon, 
                                   f.PlannedDepairport, 
                                   f.PlannedDestairport });

            /* this establishes a composite key */
            modelBuilder.Entity<VatsimClientPilotSnapshot>()
                .HasKey(p => new { p.Cid, p.Callsign, p.TimeLogon, p.TimeStamp });

        }
    }
}
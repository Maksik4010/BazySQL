using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.models;

namespace WebApplication13.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConsoleApp2.models.Job> Job { get; set; }

        public DbSet<ConsoleApp2.models.Application> Application { get; set; }

        public DbSet<ConsoleApp2.models.ApplicationType> ApplicationType { get; set; }

        public DbSet<ConsoleApp2.models.Guard> Guard { get; set; }

        public DbSet<ConsoleApp2.models.Guilt> Guilt { get; set; }

        public DbSet<ConsoleApp2.models.Location> Location { get; set; }

        public DbSet<ConsoleApp2.models.Prisoner> Prisoner { get; set; }

        public DbSet<ConsoleApp2.models.PrisonerJob> PrisonerJob { get; set; }

        public DbSet<ConsoleApp2.models.PrisonLocation> PrisonLocation { get; set; }

        public DbSet<ConsoleApp2.models.PrisonPosition> PrisonPosition { get; set; }

        public DbSet<ConsoleApp2.models.PrisonRank> PrisonRank { get; set; }

        public DbSet<ConsoleApp2.models.Schedule> Schedule { get; set; }

        public DbSet<ConsoleApp2.models.Sensor> Sensor { get; set; }

        public DbSet<ConsoleApp2.models.SensorLog> SensorLog { get; set; }

        public DbSet<ConsoleApp2.models.SensorType> SensorType { get; set; }

        
    }
}

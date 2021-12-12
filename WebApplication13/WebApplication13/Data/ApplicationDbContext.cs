using Microsoft.EntityFrameworkCore;

namespace WebApplication13.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication13.Models.Job> Job { get; set; }

        public DbSet<WebApplication13.Models.Application> Application { get; set; }

        public DbSet<WebApplication13.Models.ApplicationType> ApplicationType { get; set; }

        public DbSet<WebApplication13.Models.Guard> Guard { get; set; }

        public DbSet<WebApplication13.Models.Guilt> Guilt { get; set; }

        public DbSet<WebApplication13.Models.Location> Location { get; set; }

        public DbSet<WebApplication13.Models.Prisoner> Prisoner { get; set; }

        public DbSet<WebApplication13.Models.PrisonerJob> PrisonerJob { get; set; }

        public DbSet<WebApplication13.Models.PrisonLocation> PrisonLocation { get; set; }

        public DbSet<WebApplication13.Models.PrisonPosition> PrisonPosition { get; set; }

        public DbSet<WebApplication13.Models.PrisonRank> PrisonRank { get; set; }

        public DbSet<WebApplication13.Models.Schedule> Schedule { get; set; }

        public DbSet<WebApplication13.Models.Sensor> Sensor { get; set; }

        public DbSet<WebApplication13.Models.SensorLog> SensorLog { get; set; }

        public DbSet<WebApplication13.Models.SensorType> SensorType { get; set; }
    }
}
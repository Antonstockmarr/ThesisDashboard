using Dashboardbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboardbackend.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }

        public DbSet<Objective> objectives { get; set; }
        public DbSet<Concern> concerns { get; set; }
        public DbSet<Approach> approaches { get; set; }
        public DbSet<Tool> tools { get; set; }
        public DbSet<ApproachTool> approachTools { get; set; }    
        public DbSet<Configuration> configurations { get; set; }
        public DbSet<ConfigurationPackage> configurationPackages { get; set; }

    }
}

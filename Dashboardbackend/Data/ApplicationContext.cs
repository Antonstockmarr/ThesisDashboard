using Dashboardbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboardbackend.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }

        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Concern> Concerns { get; set; }
        public DbSet<Approach> Approaches { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ApproachTool> ApproachTools { get; set; }    
        public DbSet<SetupConfiguration> SetupConfigurations { get; set; }
    }
}

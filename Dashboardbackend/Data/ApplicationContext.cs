using Dashboardbackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

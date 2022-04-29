using Dashboardbackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data
{
    public class FocusAreaContext : DbContext
    {
        public FocusAreaContext(DbContextOptions<FocusAreaContext> opt) : base(opt)
        {

        }

        public DbSet<FocusArea> focusAreas { get; set; }
        public DbSet<Concern> concerns { get; set; }


    }
}

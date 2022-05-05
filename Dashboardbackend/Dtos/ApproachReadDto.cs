using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Dtos
{
    public class ApproachReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImplementationDifficulty { get; set; }
        public string MaintenanceDifficulty { get; set; }
        public int ConcernId { get; set; }
       // public int ToolId { get; set; }
        //public Concern concern { get; set; }
    }
}

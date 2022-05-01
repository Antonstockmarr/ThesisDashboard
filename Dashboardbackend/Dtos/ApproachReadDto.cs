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
        public string name { get; set; }
        public string description { get; set; }
        public string implementationDifficulty { get; set; }
        public string maintenanceDifficulty { get; set; }
        public int concernForeignKey { get; set; }
        //public Concern concern { get; set; }
    }
}

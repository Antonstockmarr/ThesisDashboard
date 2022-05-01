using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Dtos
{
    public class ConcernReadDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public int FocusAreaForeignKey { get; set; }
        //public FocusArea focusArea { get; set; }
    }
}

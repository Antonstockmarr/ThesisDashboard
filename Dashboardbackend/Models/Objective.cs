using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class Objective
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        //since this is a one-to-many, shouldnt we then have a list of concerns?
        // https://docs.microsoft.com/en-us/ef/core/modeling/relationships
        //public List<Concern> concerns { get; set; }
    }
}

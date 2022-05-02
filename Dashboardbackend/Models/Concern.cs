using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class Concern
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int ObjectiveId { get; set; }
        [ForeignKey("ObjectiveId")]
        public Objective Objective { get; set; }
    }
}

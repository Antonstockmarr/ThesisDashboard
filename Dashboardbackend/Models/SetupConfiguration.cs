using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class SetupConfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string SetupURL { get; set; }
        [Required]
        public string MainObjective { get; set; }
        [Required]
        public string ConfigurationDescription { get; set; }
    }
}

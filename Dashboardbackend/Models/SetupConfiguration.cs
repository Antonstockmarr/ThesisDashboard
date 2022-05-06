using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string ConfigurationDescription { get; set; }
        public ICollection<ConfigurationPackage> ConfigurationPackages { get; set; }
    }
}

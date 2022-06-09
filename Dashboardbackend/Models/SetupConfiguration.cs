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
        public string Image { get; set; }
        [Required]
        public string SetupFiles { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<ConfigurationPackage> ConfigurationPackages { get; set; }
    }
}

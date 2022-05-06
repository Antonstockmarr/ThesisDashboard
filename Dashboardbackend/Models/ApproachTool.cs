using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboardbackend.Models
{
    public class ApproachTool
    {
        [Key]
        public int Id { get; set; }
        public int ApproachId { get; set; }
        [ForeignKey("ApproachId")]
        public Approach Approach { get; set; }
        public int ToolId { get; set; }
        [ForeignKey("ToolId")]
        public Tool Tool { get; set; }
        [Required]
        public int ConfigurationDifficulty { get; set; }
        public ICollection<ConfigurationPackage> ConfigurationPackages { get; set; }

    }
}

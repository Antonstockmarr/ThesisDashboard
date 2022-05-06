using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboardbackend.Models
{
    public class Approach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImplementationDifficulty { get; set; }
        [Required]
        public string MaintenanceDifficulty { get; set; }
        public int ConcernId { get; set; }
        [ForeignKey("ConcernId")]
        public Concern Concern { get; set; }
        public ICollection<ApproachTool> ApproachTools { get; set; }

    }
}
    
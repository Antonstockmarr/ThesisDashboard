using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboardbackend.Models
{
    public class ConfigurationPackage
    {
        [Key]
        public int Id { get; set; }
        public int ApproachToolId { get; set; }
        [ForeignKey("ApproachToolId")]
        public ApproachTool ApproachTool { get; set; }
        public int ConfigurationId { get; set; }
        [ForeignKey("SetupConfigurationId")]
        public Configuration Configuration { get; set; }
    }
}

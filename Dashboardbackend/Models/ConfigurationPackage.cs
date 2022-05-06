using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class ConfigurationPackage
    {
        [Key]
        public int Id { get; set; }
        public int ApproachToolId { get; set; }
        [ForeignKey("ApproachToolId")]
        public ApproachTool ApproachTool { get; set; }
        public int SetupConfigurationId { get; set; }
        [ForeignKey("SetupConfigurationId")]
        public SetupConfiguration SetupConfiguration { get; set; }
    }
}

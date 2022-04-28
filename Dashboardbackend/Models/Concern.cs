using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class Concern
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Description { get; set; }
        //public int? focusAreaID { get; set; }
        //public virtual FocusArea focusArea { get; set; }


    }
}

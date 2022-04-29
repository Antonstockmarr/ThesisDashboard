﻿using System;
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
        public string name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int FocusAreaForeignKey { get; set; }
        [ForeignKey("FocusAreaForeignKey")]
        public FocusArea focusArea { get; set; }
    }
}

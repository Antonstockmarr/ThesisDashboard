﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Models
{
    public class Approach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string implementationDifficulty { get; set; }
        [Required]
        public string maintenanceDifficulty { get; set; }
        public int concernForeignKey { get; set; }
        [ForeignKey("concernForeignKey")]
        public Concern concern { get; set; }

    }
}
    
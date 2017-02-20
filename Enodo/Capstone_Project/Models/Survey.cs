using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name of Survey")]
        public string Name { get; set; }

        [Required]
        public string Directions { get; set; }

        public string Owner { get; set; }
    }
}
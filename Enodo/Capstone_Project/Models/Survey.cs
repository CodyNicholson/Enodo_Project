using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

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
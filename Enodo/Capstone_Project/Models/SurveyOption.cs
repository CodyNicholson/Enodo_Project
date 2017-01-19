using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class SurveyOption
    {
        [Key]
        public int Id { get; set; }

        public int OptionNumber { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
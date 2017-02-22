using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Option")]
        public string Name { get; set; }

        public int SurveyId { get; set; }
    }
}
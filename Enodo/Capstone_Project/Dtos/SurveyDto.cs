using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Dtos
{
    public class SurveyDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Directions { get; set; }

        public string Owner { get; set; }
        public string IsTaken { get; set; }
    }
}
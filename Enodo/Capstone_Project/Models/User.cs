using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class User
    {
        public Int32 Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsResearcher { get; set; }

        public DateTime? Birthdate { get; set; }

        public Survey Survey { get; set; }

        [Required]
        public string SurveyId { get; set; }
    }
}
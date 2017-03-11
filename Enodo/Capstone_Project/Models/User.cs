using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsResearcher { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public Demographic Demographic { get; set; }

        [Required]
        [Display(Name = "Ethnicity")]
        public int DemographicId { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public String Country { get; set; }

        public List<string> SurveyIds { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capstone_Project.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Capstone_Project.Dtos
{
    public class UserDto
    {
       public string Id { get; set; }

      
       
        public  string UserName { get; set; }

        public bool IsResearcher { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        [Required]
        public int DemographicId { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public List<string> SurveyIds { get; set; }
    }
}
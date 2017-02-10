using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsResearcher { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        [Required]
        public int DemographicId { get; set; }

        [Required]
        public int GenderId { get; set; }
    }
}
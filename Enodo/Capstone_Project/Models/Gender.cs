using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        public string GenderName { get; set; }
    }
}
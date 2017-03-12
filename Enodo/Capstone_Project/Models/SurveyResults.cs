using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class SurveyResults
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public int UserId { get; set; }
        
        public string OptionOrder { get; set; }
    }
}
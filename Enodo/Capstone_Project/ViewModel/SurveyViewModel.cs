using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.ViewModel
{
    public class SurveyViewModel
    {
        public List<Option> Options { get; set; }
        public SurveyResults SurveyResults { get; set; }
        public Survey Survey { get; set; }
        public ApplicationUser User { get; set; }
    }
}
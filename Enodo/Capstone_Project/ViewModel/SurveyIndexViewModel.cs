using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.ViewModel
{
    public class SurveyIndexViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
        public ApplicationUser User { get; set; }
    }
}
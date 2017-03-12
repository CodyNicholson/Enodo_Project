using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Project.Dtos
{
    public class SurveyResultsDto
    {
        public int Id { get; set; }

        public string SurveyId { get; set; }

        public string UserId { get; set; }

        public string OptionOrder { get; set; }
    }
}
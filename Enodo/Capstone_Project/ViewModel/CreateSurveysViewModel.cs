using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.ViewModel
{
    public class CreateSurveysViewModel
    {
        public IEnumerable<Option> Options { get; set; }
        public Survey Survey { get; set; }
        public int numOfOptions { get; set; }
        public User Owner { get; set; }
    }
}

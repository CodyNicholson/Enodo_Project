using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.ViewModel
{
    public class UserFormViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
        public User User { get; set; }
    }
}
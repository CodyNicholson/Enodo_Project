using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Project.Models;

namespace Capstone_Project.ViewModel
{
    public class UserFormViewModel
    {
        public IEnumerable<Demographic> Demographics { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public ApplicationUser User { get; set; }
    }
}
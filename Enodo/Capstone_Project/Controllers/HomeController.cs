using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Enodo";

            return View();
        }

        public ActionResult MeetTheTeam()
        {
            return View();
        }

        public ActionResult DevNotes()
        {
            return View();
        }
    }
}
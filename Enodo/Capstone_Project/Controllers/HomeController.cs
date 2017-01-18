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

        public ActionResult TakeSurveys()
        {
            ViewBag.Message = "Take surveys page";

            return View();
        }

        public ActionResult MyResults()
        {
            ViewBag.Message = "Your results page";

            return View();
        }

        public ActionResult CreateSurveys()
        {
            ViewBag.Message = "Create a survey";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Enodo";

            return View();
        }
    }
}
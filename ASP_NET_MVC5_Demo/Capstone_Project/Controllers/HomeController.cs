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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MyResults()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
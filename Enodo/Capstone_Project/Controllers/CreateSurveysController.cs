using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Project.Controllers
{
    public class CreateSurveysController : Controller
    {
        // GET: CreateSurveys
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOptions()
        {
            return View();
        }
    }
}
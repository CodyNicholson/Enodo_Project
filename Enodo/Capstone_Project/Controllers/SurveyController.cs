using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Microsoft.AspNet.Identity;

namespace Capstone_Project.Controllers
{
    public class SurveyController : Controller
    {
        private ApplicationDbContext _context;

        public SurveyController()
        {
            _context = new ApplicationDbContext(); // This is a disposable object, so we need to properly dispose of it
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var surveys = _context.Surveys.ToList();

            return View(surveys);
        }

        public ActionResult CreateSurveys()
        {
            return View();
        }

        public ActionResult TakeSurvey()
        {
            return View();
        }

        public ActionResult MyResults()
        {
            return View();
        }
    }
}
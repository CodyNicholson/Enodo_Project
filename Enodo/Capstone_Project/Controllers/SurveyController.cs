using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;
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

        public ActionResult CreateSurvey()
        {
            return View("CreateSurvey");
        }

        public ActionResult TakeSurvey(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);
            var options = _context.Options.ToList();

            var viewModel = new SurveyViewModel()
            {
                Options = options,
                Survey = survey
            };

            return View("TakeSurvey", viewModel);
        }

        public PartialViewResult AddOption()
        {
            //var viewModel = new SurveyViewModel()
            //{ };
            return PartialView("AddOption");
        }

        [HttpPost]
        public ActionResult Save(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                var localSurvey = survey;

                return View("SurveyForm", localSurvey);
            }

            if (survey.Id == 0)
            {
                _context.Surveys.Add(survey); // This does not write customer to the database, this is just saved in local memory
            }
            else
            {
                var surveyInDb = _context.Surveys.Single(u => u.Id == survey.Id);

                surveyInDb.Name = survey.Name;
                surveyInDb.Directions = survey.Directions;
                surveyInDb.Owner = survey.Owner;
            }

            _context.SaveChanges(); // To persist these changes, we write the customer to the database using the SaveChanges() method

            return RedirectToAction("Index", "Survey");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;
using Microsoft.Ajax.Utilities;
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
            return View();
        }

        public ActionResult CreateSurvey()
        {
            var viewModel = new SurveyViewModel()
            {
                Survey = new Survey(),
                Options = new List<Option>()
            };

            for (int i = 0; i < 30; i++)
            {
                Option newOption = new Option();
                newOption.Name = "";
                newOption.SurveyId = viewModel.Survey.Id;
                viewModel.Options.Add(newOption);
            }

            return View("CreateSurvey", viewModel);
        }

        public ActionResult TakeSurvey(int id, User user)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);
            var options = _context.Options.ToList();

            var viewModel = new SurveyViewModel()
            {
                Options = options,
                Survey = survey,
                User = user
            };

            return View("TakeSurvey", viewModel);
        }

        
        public PartialViewResult AddOption()
        {
            return PartialView("AddOption");
        }
        

        [HttpPost]
        public ActionResult Save(Survey survey, List<Option> options)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SurveyViewModel()
                {
                    Survey = new Survey()
                };

                return CreateSurvey(); 
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

            foreach (var option in options)
            {
                if (option.Name != null)
                {
                    _context.Options.Add(option);
                }
            }

            _context.SaveChanges(); // To persist these changes, we write the customer to the database using the SaveChanges() method

            var newSurvey = _context.Surveys.Single(s => s.Name == survey.Name);

            foreach (var option in _context.Options)
            {
                if (option.SurveyId == 0)
                {
                    option.SurveyId = newSurvey.Id;
                }
            }

            _context.SaveChanges(); // To persist these changes, we write the customer to the database using the SaveChanges() method

            return RedirectToAction("Index", "Survey");
        }
    }
}
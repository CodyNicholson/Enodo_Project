﻿using System;
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

        public ActionResult CreateSurvey(int id)
        {
            var user = _context.AppUsers.SingleOrDefault(u => u.Id == id);


            var viewModel = new SurveyViewModel()
            {
                Owner = user

            };

            return View("CreateSurvey", viewModel);
        }

        [HttpGet]
        public PartialViewResult AddOption()
        {
            var viewModel = new SurveyViewModel()
            { };
            return PartialView("AddOption", viewModel);
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

    }
}
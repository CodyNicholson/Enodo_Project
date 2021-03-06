﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;
using Microsoft.Ajax.Utilities;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Capstone_Project.Controllers
{
    [OutputCache(Duration = 0)]
    public class ResultsController : Controller
    {
        private ApplicationDbContext _context;

        public ResultsController()
        {
            _context = new ApplicationDbContext(); // This is a disposable object, so we need to properly dispose of it
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View();
        }

        public ActionResult ShowResults(int id)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            SurveyResults surveyResults = new SurveyResults();
            var optionOrder = HttpContext.Request.QueryString["sortorder"];

            var viewModel = new SurveyViewModel()
            {
                Survey = _context.Surveys.SingleOrDefault(s => s.Id == id)
            };

            if (viewModel.Survey == null)
            {
                return HttpNotFound();
            }
            else if (optionOrder != null)
            {
                surveyResults.OptionOrder = optionOrder;
                surveyResults.SurveyId = id;
                surveyResults.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                _context.SurveyResultsSet.Add(surveyResults);
                _context.SaveChanges();
            }

            test.runAlgorithm(id, _context);
            test.createjson(id, _context);

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Download(int id)
        {
            string file = @"~/Scripts/_output" + id + ".json";
            string contentType = "text/json";
            return File(file, contentType, Path.GetFileName(file));
        }
    }
}

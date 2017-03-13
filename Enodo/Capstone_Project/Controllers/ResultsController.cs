using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;

namespace Capstone_Project.Controllers
{
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
            return View();
        }

        public ActionResult ShowResults(int id)
        {
            int[] optionOrder = new[] {1,2,3};
            var viewModel = new SurveyViewModel()
            {
                SurveyResults = new SurveyResults(),
                Survey = _context.Surveys.SingleOrDefault(s => s.Id == id)
            };

            if (viewModel.Survey == null)
            {
                return HttpNotFound();
            }

            test.runAlgorithm(id, _context);
            test.createjson(id, _context);

            return View(viewModel);
        }
    }
}

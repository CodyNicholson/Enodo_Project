using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;

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
            var surveys = _context.Surveys.ToList();

            return View(surveys);
        }

        public ActionResult ShowResults(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (survey == null)
            {
                return HttpNotFound();
            }

            test.runAlgorithm(id, _context);
            test.createjson(id);

            return View(survey);
        }
    }
}

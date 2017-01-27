using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;

namespace Capstone_Project.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext(); // This is a disposable object, so we need to properly dispose of it
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var users = _context.AppUsers.Include(u => u.Demographic).ToList(); //When this is called Entity Framework will not query the database - this is called deferred execution

            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _context.AppUsers.SingleOrDefault(u => u.Id == id); //This will make our query execute immediately

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost] // This is here so that our Action can only be called using HttpPost and not HttpGet. By convention, if your actions modify data they should only be accessible using HttpPost
        public ActionResult Save(User user) // This is called Model Binding. MVC framework will automatically map request data to this object
        {
            // Checks if the entered information is valid based on the Customer Data Annotations
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel()
                {
                    User = user,
                    Demographics = _context.Demographics.ToList(),
                    Genders = _context.Genders.ToList()
                };
                return View("UserForm", viewModel);
            }

            if (user.Id == 0)
            {
                _context.AppUsers.Add(user); // This does not write customer to the database, this is just saved in local memory
            }
            else
            {
                var userInDb = _context.AppUsers.Single(u => u.Id == user.Id);

                userInDb.Name = user.Name;
                userInDb.Birthdate = user.Birthdate;
                userInDb.IsResearcher = user.IsResearcher;
                userInDb.DemographicId = user.DemographicId;
                userInDb.GenderId = user.GenderId;
            }

            _context.SaveChanges(); // To persist these changes, we write the customer to the database using the SaveChanges() method

            return RedirectToAction("Index", "Users");
        }

        public ActionResult New()
        {
            var demographics = _context.Demographics.ToList();
            var genders = _context.Genders.ToList();
            var viewModel = new UserFormViewModel()
            {
                Demographics = demographics,
                Genders = genders
            };

            return View("UserForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.AppUsers.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UserFormViewModel()
            {
                User = user,
                Demographics = _context.Demographics.ToList(),
                Genders = _context.Genders.ToList()
            };

            return View("UserForm", viewModel);
        }
    }
}
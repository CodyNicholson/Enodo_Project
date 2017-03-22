using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;
using System.Runtime.InteropServices;
using Microsoft.AspNet.Identity;

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
            return View();
        }

        public ActionResult Details(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id)); //This will make our query execute immediately

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost] // This is here so that our Action can only be called using HttpPost and not HttpGet. By convention, if your actions modify data they should only be accessible using HttpPost
        public ActionResult Save(ApplicationUser user) // This is called Model Binding. MVC framework will automatically map request data to this object
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

            var userInDb = _context.Users.SingleOrDefault(u => object.Equals(u.Id, user.Id));

            // System.Diagnostics.Debug.WriteLine(user.Id + "SIUJAHFHASDIFJHIDSUAHFIOUDSHFIUDSHFUHI");
            if (userInDb == null)
            {
                _context.Users.Add(user); // This does not write customer to the database, this is just saved in local memory
            }
            else
            {
               
               // ApplicationUser t = _context.Users.First();
               // var ttt = t.Id;
                

                userInDb.UserName = user.UserName;
                userInDb.Birthdate = user.Birthdate;
                userInDb.Country = user.Country;
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
                Genders = genders,
                User = new ApplicationUser()
            };

            return View("UserForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            var currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

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

            if (id != currentUserId)
            {
                return View("Details", viewModel);
            }
            else
            {
                return View("UserForm", viewModel);
            }
        }
    }
}
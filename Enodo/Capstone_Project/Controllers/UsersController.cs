using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;

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
            var users = _context.AppUsers.ToList(); //When this is called Entity Framework will not query the database - this is called deferred execution

            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _context.AppUsers.SingleOrDefault(c => c.Id == id); //This will make our query execute immediately

            if (user == null)
                return HttpNotFound();

            return View(user);
        }
    }
}
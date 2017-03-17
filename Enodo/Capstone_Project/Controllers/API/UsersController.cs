using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Capstone_Project.Dtos;
using Capstone_Project.Models;
using Microsoft.AspNet.Identity;

namespace Capstone_Project.Controllers.api
{
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
           _context = new ApplicationDbContext();
        }

        // GET: /api/users
        public IHttpActionResult GetUsers()
        {
            //var user = _context.Users;
            var userDtos = _context.Users
                .ToList()
               .Select(Mapper.Map<ApplicationUser, UserDto>);

            if (userDtos == null)
                return NotFound();

            return Ok(userDtos);
        }

        // GET /api/user/id
        public IHttpActionResult GetUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id.Equals(id));

            

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<ApplicationUser, UserDto>(user));
        }

            // POST /api/users
            [System.Web.Mvc.HttpPost] // Since we are creating a resource we use HttpPost
            public IHttpActionResult CreateUser(UserDto userDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = Mapper.Map<UserDto, ApplicationUser>(userDto);
                _context.Users.Add(user);
                _context.SaveChanges();

                userDto.Id = user.Id;

                return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
            }

            // PUT /api/users/id
            [System.Web.Mvc.HttpPut]
            public IHttpActionResult UpdateUser(string id, UserDto userDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var userInDb = _context.Users.SingleOrDefault(c => c.Id.Equals(id));

                if (userInDb == null)
                    return NotFound();

                Mapper.Map(userDto, userInDb);

                _context.SaveChanges();

                return Ok();
            }

            // DELETE /api/users/id
            [System.Web.Mvc.HttpDelete]
            public IHttpActionResult DeleteUser(string id)
            {
                var userInDb = _context.Users.SingleOrDefault(c => c.Id.Equals(id));

                if (userInDb == null)
                    return NotFound();

             _context.Users.Remove(userInDb);
             _context.SaveChanges();

             return Ok();
            }
    }
}
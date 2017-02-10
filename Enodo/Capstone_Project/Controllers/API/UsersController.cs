using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Capstone_Project.Dtos;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers.api
{
    public class UsersController : Controller
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
                var userDtos = _context.AppUsers.ToList().Select(Mapper.Map<User, UserDto>);

                return Ok(userDtos);
            }

            // GET /api/user/id
            public IHttpActionResult GetUser(int id)
            {
                var user = _context.AppUsers.SingleOrDefault(c => c.Id == id);

                if (user == null)
                    return NotFound();

                return Ok(Mapper.Map<User, UserDto>(user));
            }

            // POST /api/users
            [System.Web.Mvc.HttpPost] // Since we are creating a resource we use HttpPost
            public IHttpActionResult CreateUser(UserDto userDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = Mapper.Map<UserDto, User>(userDto);
                _context.AppUsers.Add(user);
                _context.SaveChanges();

                userDto.Id = user.Id;

                return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
            }

            // PUT /api/users/id
            [System.Web.Mvc.HttpPut]
            public IHttpActionResult UpdateUser(int id, UserDto userDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var userInDb = _context.AppUsers.SingleOrDefault(c => c.Id == id);

                if (userInDb == null)
                    return NotFound();

                Mapper.Map(userDto, userInDb);

                _context.SaveChanges();

                return Ok();
            }

            // DELETE /api/users/id
            [System.Web.Mvc.HttpDelete]
            public IHttpActionResult DeleteUser(int id)
            {
                var userInDb = _context.AppUsers.SingleOrDefault(c => c.Id == id);

                if (userInDb == null)
                    return NotFound();

                _context.AppUsers.Remove(userInDb);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}
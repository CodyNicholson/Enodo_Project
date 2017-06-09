using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Capstone_Project.Dtos;
using Capstone_Project.Models;
using Microsoft.AspNet.Identity;

namespace Capstone_Project.Controllers.api
{
    public class SurveyController : ApiController
    {
        private ApplicationDbContext _context;

        public SurveyController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/surveys
        public IHttpActionResult GetSurveys()
        {
            var surveyDtos = _context.Surveys.ToList().Select(Mapper.Map<Survey, SurveyDto>);

            return Ok(surveyDtos);
        }

        // GET /api/survey/id
        public IHttpActionResult GetSurvey(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(c => c.Id == id);

            if (survey == null)
                return NotFound();

            return Ok(Mapper.Map<Survey, SurveyDto>(survey));
        }

        // POST /api/surveys
        [HttpPost] // Since we are creating a resource we use HttpPost
        public IHttpActionResult CreateSurvey(SurveyDto surveyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var survey = Mapper.Map<SurveyDto, Survey>(surveyDto);
            _context.Surveys.Add(survey);
            _context.SaveChanges();

            surveyDto.Id = survey.Id;

            return Created(new Uri(Request.RequestUri + "/" + survey.Id), surveyDto);
        }

        // PUT /api/surveys/id
        [HttpPut]
        public IHttpActionResult UpdateSurvey(int id, SurveyDto surveyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var surveyInDb = _context.Surveys.SingleOrDefault(c => c.Id == id);

            if (surveyInDb == null)
                return NotFound();

            Mapper.Map(surveyDto, surveyInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/surveys/id
        [HttpDelete]
        public IHttpActionResult DeleteSurvey(int id)
        {
            var surveyInDb = _context.Surveys.SingleOrDefault(c => c.Id == id);
            var optionsInDb = _context.Options.Where(o => o.SurveyId == id);
            var surveyResultsInDb = _context.SurveyResultsSet.Where(o => o.SurveyId == id);

            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = _context.Users.Single(u => u.Id == currentUserId);

            if (surveyInDb == null)
                return NotFound();

            if (currentUser.UserName == surveyInDb.Owner)
            {
                foreach (var option in optionsInDb)
                {
                    _context.Options.Remove(option);
                }

                foreach (var surveyResult in surveyResultsInDb)
                {
                    _context.SurveyResultsSet.Remove(surveyResult);
                }

                _context.Surveys.Remove(surveyInDb);
                _context.SaveChanges();

                return Ok();
            }

            return null;
        }
    }
}
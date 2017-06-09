using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Capstone_Project.Dtos;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers.api
{
    [OutputCache(Duration = 0)]
    public class ResultsController : ApiController
    {
        private ApplicationDbContext _context;

        public ResultsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/results
        public IHttpActionResult GetResults()
        {
            var surveyResultsDtos = _context.SurveyResultsSet.ToList().Select(Mapper.Map<SurveyResults, SurveyResultsDto>);

            return Ok(surveyResultsDtos);
        }

        // GET /api/results/id
        public IHttpActionResult GetSurveyResults(int id)
        {
            var surveyResults = _context.SurveyResultsSet.SingleOrDefault(c => c.Id == id);

            if (surveyResults == null)
                return NotFound();

            return Ok(Mapper.Map<SurveyResults, SurveyResultsDto>(surveyResults));
        }

        // POST /api/results
        [System.Web.Http.HttpPost] // Since we are creating a resource we use HttpPost
        public IHttpActionResult CreateSurveyResults(SurveyResultsDto surveyResultsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var surveyResults = Mapper.Map<SurveyResultsDto, SurveyResults>(surveyResultsDto);
            _context.SurveyResultsSet.Add(surveyResults);
            _context.SaveChanges();

            surveyResultsDto.Id = surveyResults.Id;

            return Created(new Uri(Request.RequestUri + "/" + surveyResults.Id), surveyResultsDto);
        }

        // PUT /api/results/id
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateSurveyResults(int id, SurveyResultsDto surveyResultsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var surveyResultsInDb = _context.SurveyResultsSet.SingleOrDefault(c => c.Id == id);

            if (surveyResultsInDb == null)
                return NotFound();

            Mapper.Map(surveyResultsDto, surveyResultsInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/results/id
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteSurveyResults(int id)
        {
            var surveyResultsInDb = _context.SurveyResultsSet.SingleOrDefault(c => c.Id == id);

            if (surveyResultsInDb == null)
                return NotFound();

            _context.SurveyResultsSet.Remove(surveyResultsInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

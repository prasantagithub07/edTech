using edTech.DomainModels.Entities;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace edTech.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseTopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public CourseTopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        [HttpGet]
        public IEnumerable<CourseTopic> GetAll()
        {
            return _topicService.GetAllTopics();
        }

        [HttpGet("{id}")]
        public CourseTopic Get(int id)
        {
            return _topicService.Find(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<CourseTopic> GetTopicByCourse(int id)
        {
            return _topicService.GetTopicsByCourse(id);
        }

        [HttpPost]
        public IActionResult Add(CourseTopic model)
        {
            try
            {
                _topicService.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseTopic model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _topicService.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _topicService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}

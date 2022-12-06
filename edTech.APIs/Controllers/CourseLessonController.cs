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
    public class CourseLessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public CourseLessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }   
        [HttpGet]
        IEnumerable<CourseLesson> GetAll()
        {
            return _lessonService.GetAll();
        }

        [HttpGet("{id}")]
        public IEnumerable<CourseLesson> GetLessonsByTopic(int id)
        {
            return _lessonService.GetLessonsByTopic(id);
        }

        [HttpPost]
        public IActionResult Add(CourseLesson model)
        {
            try
            {
                _lessonService.Add(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseLesson model)
        {
            try{
                if (id != model.Id)
                    return BadRequest();

                _lessonService.Update(model);
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
                _lessonService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}

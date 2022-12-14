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
    public class CourseController : ControllerBase
    {
        private readonly IService<Course> _courseService;
        private readonly ISubscriptionService _subscriptionService;

        public CourseController(IService<Course> courseService, ISubscriptionService subscriptionService)
        {
            _courseService = courseService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            return _courseService.GetAll();
        }


        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return _courseService.Find(id);
        }

        [HttpPost]
        public IActionResult Add(Course model)
        {
            try
            {
                _courseService.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course model)
        {
            try
            {
                if(id != model.Id)
                    return BadRequest();

                _courseService.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _courseService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{UserId}/{CourseId}")]
        public Subscription GetCourseSubscription(int UserId, int CourseId)
        {
            return _subscriptionService.GetUserSubscription(UserId, CourseId);
        }

        [HttpGet("{UserId}")]
        public IEnumerable<Course> GetSubcribedCourses(int UserId)
        {
            return _subscriptionService.GetSubscribedCourses(UserId);
        }
    }
}

using edTech.APIs.Filters;
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
    [CustomAuthorize]
    public class MentorController : ControllerBase
    {
        private readonly IService<Mentor> _service;

        public MentorController(IService<Mentor> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Mentor> GetAll()
        {
            return _service.GetAll();   
        }

        [HttpGet("{id}")]
        public Mentor Get(int id)
        {
            return _service.Find(id);
        }

        [HttpPost]
        public IActionResult Add(Mentor model)
        {
            try
            {
                _service.Add(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , Mentor model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _service.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

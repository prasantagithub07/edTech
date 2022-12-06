using edTech.APIs.Filters;
using edTech.DomainModels.Entities;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category> _service;
        public CategoryController(IService<Category> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public IActionResult Add(Category model)
        {
            try
            {
                _service.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

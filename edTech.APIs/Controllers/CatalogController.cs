using edTech.DomainModels.Entities;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace edTech.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICourseService _service;
        public CatalogController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        public Course GetCourseWithLessons(string Url)
        {
            Url = "/Course" + Url;
            return _service.GetCourseWithLessons(Url);
        }
    }
}

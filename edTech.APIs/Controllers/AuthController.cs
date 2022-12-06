using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace edTech.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        public AuthController(IAuthenticationService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public IActionResult CreateUser(UserSignUpModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber=model.PhoneNumber
            };
            var result = _service.CreateUser(user, model.Password);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }

        [HttpPost]
        public IActionResult ValidateUser(LoginModel model)
        {

            var result = _service.AuthenticateUser(model.Username, model.Password);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid Username or Password");
            }
            else
            {
                
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}

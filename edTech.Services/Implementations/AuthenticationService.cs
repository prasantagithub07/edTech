using edTech.DAL;
using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signInManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;
        protected IConfiguration _config;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Name),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Roles", string.Join(",",userInfo.Roles))
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.UtcNow.AddMinutes(60),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
        public UserModel AuthenticateUser(string Username, string Password)
        {
            var result = _signInManager.PasswordSignInAsync(Username,Password,false,lockoutOnFailure:false).Result;
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(Username).Result;
                var roles = _userManager.GetRolesAsync(user).Result;

                UserModel model = new UserModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles.ToArray()
                };
                model.Token = GenerateJSONWebToken(model);
                return model;
            }
            return null;
        }

        public bool CreateUser(User user, string Password)
        {
            string strError = string.Empty;

            var result = _userManager.CreateAsync(user, Password).Result;
            if (result.Succeeded)
            {
                //Admin, User
                string role = "User";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return true;
                    //transaction.Commit();
                }
            }
            else
            {
                foreach( var e in result.Errors)
                {
                    strError += e.ToString();
                }
            }

            return false;
        }

        ////old code
        //public bool CreateUser(User user, string Password)
        //{
        //    var result = _userManager.CreateAsync(user, Password).Result;
        //    if (result.Succeeded)
        //    {
        //        //Admin, User
        //        string role = "Admin";
        //        var res = _userManager.AddToRoleAsync(user, role).Result;
        //        if (res.Succeeded)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public User GetUser(string Username)
        {
            return _userManager.FindByNameAsync(Username).Result;   
        }

        public bool SignOut()
        {
            _signInManager.SignOutAsync().Wait();
            return true;
        }
    }
}

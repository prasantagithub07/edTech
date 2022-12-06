﻿using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool CreateUser(User user , string Password);
        bool SignOut();
        UserModel AuthenticateUser(string Username, string Password);
        User GetUser(string Username);
    }
}

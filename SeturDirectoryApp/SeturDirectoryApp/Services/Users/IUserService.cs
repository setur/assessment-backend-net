using Microsoft.AspNetCore.Mvc;
using SeturDirectoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturDirectoryApp.Services.Users
{
   public interface IUserService
    {
        Task<string> GetUserById(int id);

        Task<ActionResult<User>> GetUser(int id);

        Task<User> GetUserDetails(int id);
    }
}

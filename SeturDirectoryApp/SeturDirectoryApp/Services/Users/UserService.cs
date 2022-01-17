using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturDirectoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturDirectoryApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly mytestdbContext _mytestdbContext;


        public UserService(mytestdbContext Context)
        {
            _mytestdbContext = Context;
        }

        public async Task<string> GetUserById(int id)
        {
            var name = await _mytestdbContext.Users.Where(c => c.Uuid == id).Select(d => d.Name).FirstOrDefaultAsync();
            return name;
        }

        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _mytestdbContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User> GetUserDetails(int id)
        {
            var emp = await _mytestdbContext.Users.FirstOrDefaultAsync(c => c.Uuid == id);
            return emp;
        }
    }
}

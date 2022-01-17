using Konatsu.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konatsu.API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async void AddUser(string username)
        {
            var appUser = new AppUser
            {
                Username = username,
            };

            var result = await _context.AddAsync(appUser);
            await _context.SaveChangesAsync();
        }
        public void DeleteUser(AppUser user)
        {
            var result = _context.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(int id)
        {
            var result = await _context.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotiAPI.Models;

namespace NotiAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            User userToDelete = await _context.Users.FindAsync(id);
            _context.Remove(userToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdatePassword(int id, string newPassword)
        {
            /*
            User userToUpdatePassword = await _context.Users.FindAsync(id);
            string oldPassword = userToUpdatePassword.Password;

            _context.Entry(userToUpdatePassword.Password).State = EntityState.Modified;
            userToUpdatePassword.Password.Replace(oldPassword, newPassword);
            */

            //_context.Entry(user).State = EntityState.Modified;
            User user = new User() { UserId = id, Password = newPassword };
            _context.Users.Attach(user);
            _context.Entry(user).Property(x => x.Password).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}

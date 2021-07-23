using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotiAPI.Models;

namespace NotiAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);
        Task<User> Create(User user);
        Task UpdatePassword(int userId, string newPassword);
        Task Delete(int id);
    }
}

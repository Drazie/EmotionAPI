using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotiAPI.Models;
using NotiAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<User> GetUsers(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUsers([FromBody] User user)
        {
            User newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.UserId }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            User userToDelete = await _userRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(userToDelete.UserId);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserPassword(int id, [FromBody] string newPassword)
        {
            await _userRepository.UpdatePassword(id, newPassword);

            return NoContent();
        }
    }
}

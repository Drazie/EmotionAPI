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
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notiRepository;

        public NotificationController(INotificationRepository notiRepository)
        {
            _notiRepository = notiRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _notiRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Notification> GetNotifications(int id)
        {
            return await _notiRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification([FromBody] Notification noti)
        {
            Notification newNotification = await _notiRepository.Create(noti);
            return CreatedAtAction(nameof(GetNotifications), new { id = newNotification.NotificationId }, newNotification);
        }

        [HttpPut]
        public async Task<ActionResult> PutNotification(int id, [FromBody] Notification noti)
        {
            if (id != noti.NotificationId)
            {
                return BadRequest();
            }

            await _notiRepository.Update(noti);

            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteNotification(int id)
        {
            Notification notificationToDelete = await _notiRepository.Get(id);
            if (notificationToDelete == null)
            {
                return NotFound();
            }
            await _notiRepository.Delete(notificationToDelete.NotificationId);
            return NoContent();
        }
    }
}

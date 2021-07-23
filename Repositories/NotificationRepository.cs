using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotiAPI.Models;

namespace NotiAPI.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationContext _context;

        public NotificationRepository(NotificationContext context)
        {
            _context = context;
        }

        public async Task<Notification> Create(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        public async Task Delete(int id)
        {
            Notification notiToDelete = _context.Notifications.Find(id);
            _context.Notifications.Remove(notiToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> Get()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> Get(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task Update(Notification notification)
        {
            _context.Entry(notification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

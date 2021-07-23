using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotiAPI.Models;

namespace NotiAPI.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> Get();
        Task<Notification> Get(int id);
        Task<Notification> Create(Notification notification);
        Task Update(Notification notification);
        Task Delete(int id);
    }
}

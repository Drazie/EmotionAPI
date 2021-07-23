using System;
using System.ComponentModel.DataAnnotations;

namespace NotiAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public int RarityRating { get; set; }
    }
}

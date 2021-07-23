using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotiAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthorized { get; set; }


        //[ForeignKey("NotificationId")]
        //public List<int> NotificationsReceived { get; set; }

        //INSERT INTO newDatabase.table1 (Column1, Column2) 
        //SELECT column1, column2 FROM oldDatabase.table1;

    }
}

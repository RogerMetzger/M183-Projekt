using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{
    public class UserLog
    {
        public UserLog(string action, User user)
        {
            Action = action;
            User = user;
        }

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{
    public class UserLogin
    {
        public UserLogin(int userId, string sessionId, string ip)
        {
            UserId = userId;
            SessionId = sessionId;
            Ip = ip;
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Ip { get; set; }
        public string SessionId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
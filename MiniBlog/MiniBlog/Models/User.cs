using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{
    public sealed class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
            this.Tokens = new HashSet<Token>();
            this.Userlogins = new HashSet<UserLogin>();
            this.UserLogs = new HashSet<UserLog>();
        }
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Familyname { get; set; }
        public string Mobilephonenumber { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }      
      
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserLogin> Userlogins { get; set; }
        public ICollection<UserLog> UserLogs { get; set; }
        public ICollection<Token> Tokens { get; set; }
    }
}
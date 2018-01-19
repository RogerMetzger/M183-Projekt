using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{
    public class Post
    {
        public Post()
        {
            this.Comment = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public PostStatus Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
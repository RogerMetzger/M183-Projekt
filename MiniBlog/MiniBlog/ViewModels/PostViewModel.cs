using MiniBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBlog.ViewModels
{
    public class PostViewModel
    {
        Post post;
        IEnumerable<Comment> comments;

        public PostViewModel(Post post)
        {
            this.post = post;
            this.comments = post.Comment;
        }

        public PostViewModel() { }

        public IEnumerable<Comment> Comments
        {
            get
            {
                return this.comments;
            }
        }
        public Post Post
        {
            get
            {
                return this.post;
            }
            set
            {
                this.post = value;
            }
        }
    }
}
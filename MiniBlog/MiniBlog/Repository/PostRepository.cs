using MiniBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBlog.Repository
{
    public class PostRepository : Repository
    {
        public PostRepository(MiniBlogContext db)
            : base(db)
        {
        }

        public IEnumerable<Post> GetPosts()
        {
            return this.Db.Posts.ToList();
        }

        public IEnumerable<Post> GetPublicPosts()
        {
            return this.Db.Posts.Where(p => p.Status == PostStatus.Public).ToList();
        }

        public IEnumerable<Post> GetPrivatePosts()
        {
            return this.Db.Posts.Where(p => p.Status == PostStatus.Private).ToList();
        }

    }
}
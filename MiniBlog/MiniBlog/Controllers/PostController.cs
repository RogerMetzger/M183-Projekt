using MiniBlog.Models;
using MiniBlog.Repository;
using MiniBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBlog.Controllers
{
    public class PostController : Controller
    {
        MiniBlogContext db = new MiniBlogContext();

        public ActionResult Index(int id)
        {
            return View("Index", new PostViewModel(db.Posts.FirstOrDefault(p => p.Id == id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int postid, string comment)
        {
            db.Posts.First(p => p.Id == postid).Comment.Add(new Comment() { Commet = comment, PostId = postid, UserId = 1 });
            db.SaveChanges();

            return View("Index", new PostViewModel(db.Posts.FirstOrDefault(p => p.Id == postid)));
        }
    }
}
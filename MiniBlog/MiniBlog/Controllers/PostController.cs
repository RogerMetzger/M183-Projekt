using MiniBlog.Models;
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
        public ActionResult AddComment(int id, string comment)
        {
            db.Posts.FirstOrDefault(p => p.Id == id).Comment.Add(new Comment() { Commet = comment, PostId = id, UserId = 1 }); // Todo add userId from Session

            return View("Index", new PostViewModel(db.Posts.FirstOrDefault(p => p.Id == id)));
        }
    }
}
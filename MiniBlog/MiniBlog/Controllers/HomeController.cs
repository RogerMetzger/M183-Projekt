using MiniBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniBlog.Common;
using MiniBlog.Repository;
using MiniBlog.ViewModels;

// Fragen:
// 1) RFC2899 hält den Public Key Kryptographie Standard ein. Ebenso ist eine genormte Funktion. 
//    Der Hauptgrund ist, dass es relativ einfach aufzusetzten ist und von National Institut of Standards and Technologie empfohlen wurde.
// 2) Session ID theft & Eavesdropping
// 3) In dem man die Session ID aus den Cookies klaut kann man dem Server vorgaukeln, dass man eine andere Person ist.
//    In dem man die IP Adresse in der Db speichert kann man beim erneuten Login überprüfen, ob die immernoch übereinstimmen.


namespace MiniBlog.Controllers
{
    public class HomeController : Controller
    {
        public MiniBlogContext db = new MiniBlogContext();

        // GET: Home
        public ActionResult Index()
        {
            PostRepository postRepository = new PostRepository(db);
            IEnumerable<Post> posts = postRepository.GetPublicPosts();
            return View(new HomeViewModel(posts));
        }

        public ActionResult Seed()
        {
            User myUser = new User
            {
                Username = "SilverBlood",
                Password = PasswordUtilities.HashPassword("12345", 10000),
                Firstname = "Roger",
                Familyname = "Metzger",
                Mobilephonenumber = "0041774893231",
                Role = "1",
                Status = "aktiv"
            };

            User user = new User()
            {
                Username = "C3D1",
                Password = PasswordUtilities.HashPassword("12345", 10000),
                Firstname = "Cedric",
                Familyname = "Schnider",
                Mobilephonenumber = "0041792233423",
                Role = "1",
                Status = "aktiv"
            };

            Comment myComment = new Comment
            {
                Commet = "Das ist Kommentar",
                CreatedOn = DateTime.Today,
                User = myUser
            };

            Post publicPost = new Post()
            {
                Content = "Inhalt eines Post",
                CreatedOn = DateTime.Now,
                Description = "Die Beschreibung meines Kommentar",
                Status = PostStatus.Public,
                Title = "Public Post",
                User = myUser

            };
            publicPost.Comment.Add(myComment);
            publicPost.Comment.Add(myComment);
            publicPost.Comment.Add(myComment);
            Post privatePost = new Post()
            {
                Content = "Ein weiterer Inhalt eines Posts",
                CreatedOn = DateTime.Now,
                Description = "Die Beschreibung des zweiten Posts",
                Status = PostStatus.Private,
                Title = "Private Post",
                User = myUser
            };
            privatePost.Comment.Add(myComment);
            privatePost.Comment.Add(myComment);
            privatePost.Comment.Add(myComment);

            db.Users.Add(myUser);
            db.Posts.Add(privatePost);
            db.Posts.Add(publicPost);
            db.Users.Add(user);
            db.Comments.Add(myComment);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
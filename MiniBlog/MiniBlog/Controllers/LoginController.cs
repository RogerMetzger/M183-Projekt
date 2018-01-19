using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MiniBlog.Common;
using MiniBlog.Models;
using MiniBlog.ViewModels;

namespace MiniBlog.Controllers
{
    public class LoginController : Controller
    {
        public MiniBlogContext db = new MiniBlogContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Username == model.Username))
                {
                    User user = db.Users.First(x => x.Username == model.Username);
                    if (PasswordUtilities.CheckPassword(model.Password, user.Password))
                    {
                        //TODO go to token view
                        return View();
                    }
                    ModelState.AddModelError("Password", "Password wrong");
                    return View("Index", model);
                }
                else
                {           
                    ModelState.AddModelError("Username", "No User with this Username");
                    return View("Index", model);
                }
            }
            return View("Index", model);
        }
    }
}
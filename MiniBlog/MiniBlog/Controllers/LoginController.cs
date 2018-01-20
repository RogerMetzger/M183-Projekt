using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.ApplicationInsights.Web;
using MiniBlog.Common;
using MiniBlog.Models;
using MiniBlog.Repository;
using MiniBlog.Services;
using MiniBlog.ViewModels;

namespace MiniBlog.Controllers
{
    public class LoginController : Controller
    {
        private MiniBlogContext db = new MiniBlogContext();

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
            LoginRepository loginRepository = new LoginRepository(db);
            if (ModelState.IsValid)
            {
                if (loginRepository.CheckIfUserExists(model.Username))
                {
                    User user = loginRepository.GetUserByName(model.Username);
                    if (PasswordUtilities.CheckPassword(model.Password, user.Password))
                    {
                        Token token = new Token
                        {
                            User = user,
                            UserId = user.Id,
                            TokenNr = new Random().Next(1, 999999),
                            Expiry = DateTime.Now.AddMinutes(5)
                        };
                        TokenRepository tokenRepository = new TokenRepository(db);
                        tokenRepository.AddToken(token);

                        new MobileService().SendSMS(token.TokenNr, user.Mobilephonenumber);
                        return View("Token", new TokenViewModel() {UserId = user.Id});
                    }

                    loginRepository.Log("Password wrong", user.Id);
                    ModelState.AddModelError("Password", "Password wrong");
                    return View("Index", model);
                }

                loginRepository.Log("Login failed", null);
                ModelState.AddModelError("Username", "No User with this Username");
                return View("Index", model);
            }

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Token(TokenViewModel model)
        {
            TokenRepository tokenRepository = new TokenRepository(db);
            LoginRepository loginRepository = new LoginRepository(db);
            PostRepository postRepository = new PostRepository(db);
            if (tokenRepository.CheckToken(model.Token, model.UserId))
            {
                Session["a_name_for_our_session_thant_cant_be_exposed"] = generateID();

                loginRepository.Log("Login successful", model.UserId);
                loginRepository.LogUserLogin(model.UserId,
                    Session["a_name_for_our_session_thant_cant_be_exposed"].ToString(), Request.UserHostAddress);

                return View("../Home/Index", new HomeViewModel(postRepository.GetPublicPosts()));
            }

            loginRepository.Log("Token invalid", model.UserId);
            ViewBag.Status = "invalid token";
            ModelState.AddModelError("Token", "Token is invalid");
            return View("Token", model);
        }

        private string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
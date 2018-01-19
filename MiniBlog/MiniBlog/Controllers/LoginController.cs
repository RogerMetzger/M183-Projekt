using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
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
                        return View("Token", new TokenViewModel() { UserId = user.Id });
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

        [HttpPost]
        public ActionResult TokenLogin(TokenViewModel model)
        {
            TokenRepository tokenRepository = new TokenRepository(db);
            if (tokenRepository.CheckToken(model.Token, model.UserId))
            {
                return View("Index");
            }
            ViewBag.Status = "invalid token";
            ModelState.AddModelError("Token", "Token is invalid");
            return View("Token", model);
        }
    }
}
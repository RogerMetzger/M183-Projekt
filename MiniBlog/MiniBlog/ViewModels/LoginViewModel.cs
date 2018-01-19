using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniBlog.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nutzername")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
    }
}
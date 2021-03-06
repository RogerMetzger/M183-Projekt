﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniBlog.ViewModels
{
    public class TokenViewModel
    {
        [Required]
        [Display(Name = "Token")]
        public int Token { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
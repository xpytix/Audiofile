﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Audiofile.Models;
using System.ComponentModel.DataAnnotations;

namespace Audiofile.ViewModels
{
    public class ManageCredentialsViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public Audiofile.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public DaneUzytkownika DaneUzytkownika { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

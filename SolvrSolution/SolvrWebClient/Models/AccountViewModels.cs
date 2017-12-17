using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolvrWebClient.Models
{

    public class LoginViewModel
    {
        [Required]
        [AllowHtml]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [AllowHtml]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long and less than 50 characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long and less than 50 characters long.", MinimumLength = 2)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [AllowHtml]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and less than 100 characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [AllowHtml]
        //Compare attribute is ambigues between two "ComponentModel.Dataannotations" and "Web.MVC"
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}

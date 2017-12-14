using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolvrWebClient.Models
{
    public class PostViewModel
    {
        [Required]
        [AllowHtml]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and less than 100 characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long and less than 1500 characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [AllowHtml]
        [StringLength(300)]
        public string TagsString { get; set; }

        public int postId { get; set; }
    }

    public class PhysicalPostViewModel
    {
        [Required]
        [AllowHtml]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long and less than 100 characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long and less than 1500 characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [AllowHtml]
        [StringLength(300)]
        public string TagsString { get; set; }

        [AllowHtml]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long and less than 1000 characters long.", MinimumLength = 5)]
        public string AltDescription { get; set; }

        [AllowHtml]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long and less than 10 characters long.", MinimumLength = 3)]
        public string Zipcode { get; set; }

        [AllowHtml]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long and less than 50 characters long.", MinimumLength = 3)]
        public string Address { get; set; }

        public int postId { get; set; }

        public bool IsLocked { get; set; }
    }
}
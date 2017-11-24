﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolvrWebClient.Models
{
    public class PostViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [StringLength(300)]
        public string TagsString { get; set; }
    }

    public class PhysicalPostViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [StringLength(300)]
        public string TagsString { get; set; }
        
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string AltDescription { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Zipcode { get; set; }
        
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Address { get; set; }
    }
}
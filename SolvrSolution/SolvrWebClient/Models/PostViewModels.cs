using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolvrWebClient.Models
{
    public class CommentViewModel
    {
        [Required]
        [AllowHtml]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long  and less than 1500 characters long.", MinimumLength = 1)]
        public string Text { get; set; }

        public int PostId { get; set; }

        public bool IsSolvr { get; set; }
    }

    public class ReportViewModel
    {
        [Required]
        [AllowHtml]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long  and less than 300 characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long  and less than 2000 characters long.", MinimumLength = 10)]
        public string Description { get; set; }

        public string ReportType { get; set; }


        public int PostId { get; set; }

        public int UserId { get; set; }

        public int CommentId { get; set; }

    }
}
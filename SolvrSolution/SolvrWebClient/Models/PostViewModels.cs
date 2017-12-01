using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolvrWebClient.Models
{
    public class CommentViewModel
    {
        [Required]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Text { get; set; }

        public int PostId { get; set; }

        public bool IsSolvr { get; set; }
    }
}
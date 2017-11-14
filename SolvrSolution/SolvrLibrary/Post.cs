using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public Category PostCategory { get; set; }
        public List<Comment> Comments { get; set; }
        public string Tite { get; set; }
        public string Description { get; set; }
        public DateTime BumpTime { get; set; }
        public List<string> Tags { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

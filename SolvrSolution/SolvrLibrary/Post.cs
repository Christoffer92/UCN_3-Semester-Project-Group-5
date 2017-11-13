using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class Post
    {
        public Category PostCategory { get; set; }
        public List<Comment> Comments { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BumpTime { get; set; }
        public List<String> Tags { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class Comment
    {
        public User UserComment { get; set; }
        public List<Vote> Votes { get; set; }
        public int CommentID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "comments")]
    public class CommentSuper
    {


        [Column()]
        public DateTime DateCreated { get; set; }

        [Column()]
        public string Text { get; set; }

        [Column()]
        public int UserId { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }

        public List<Vote> Votes { get; set; }

    }
}

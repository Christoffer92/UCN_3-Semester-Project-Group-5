using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "posts")]
    public class Post
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public string Title { get; set; }

        [Column()]
        public string Description { get; set; }

        [Column()]
        public DateTime BumpTime { get; set; }

        [Column()]
        public DateTime DateCreated { get; private set; }

        public List<string> Tags { get; set; }

        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

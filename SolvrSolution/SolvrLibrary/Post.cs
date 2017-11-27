using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "posts")]
    [InheritanceMapping(Code = "Physical", Type = typeof(PhysicalPost))]
    [InheritanceMapping(Code = "Post", Type = typeof(Post), IsDefault = true)]
    public class Post
    {

        public Post()
        {
            BumpTime = DateTime.Now;
            DateCreated = DateTime.Now;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public string Title { get; set; }

        [Column()]
        public string Description { get; set; }

        [Column()]
        public DateTime BumpTime { get; set; }

        [Column()]
        public DateTime DateCreated { get; set; }

        [Column()]
        public int CategoryId { get; set; }

        [Column()]
        public int UserId { get; set; }

        [Column(IsDiscriminator = true)]
        public string PostType;

        public List<string> Tags { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }

    }
}

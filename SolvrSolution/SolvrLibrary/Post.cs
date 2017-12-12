using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [KnownType(typeof(PhysicalPost))]
    [Table(Name = "posts")]
    [InheritanceMapping(Code = "Physical", Type = typeof(PhysicalPost))]
    [InheritanceMapping(Code = "Post", Type = typeof(Post), IsDefault = true)]
    public class Post
    {

        public Post()
        {
            Tags = new List<string>();
            Comments = new List<Comment>();
            BumpTime = DateTime.Now;
            DateCreated = DateTime.Now;
            Tags = new List<string>();
            Comments = new List<Comment>();
        }
        [DataMember]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [DataMember]
        [Column()]
        public string Title { get; set; }

        [DataMember]
        [Column()]
        public string Description { get; set; }

        [DataMember]
        [Column()]
        public DateTime BumpTime { get; set; }

        [DataMember]
        [Column()]
        public DateTime DateCreated { get; set; }

        [DataMember]
        [Column()]
        public int CategoryId { get; set; }

        [DataMember]
        [Column()]
        public int UserId { get; set; }

        [DataMember]
        [Column(IsDiscriminator = true)]
        public string PostType;

        [DataMember]
        [Column()]
        public bool IsDisabled { get; set; }

        [DataMember]
        public List<string> Tags { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public List<Comment> Comments { get; set; }
    }
}
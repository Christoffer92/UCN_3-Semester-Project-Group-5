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
    [KnownType(typeof(PhysicalPost))]
    [DataContract]
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
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public DateTime BumpTime { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        [Column()]
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        [Column(IsDiscriminator = true)]
        [DataMember]
        public string PostType;

        [DataMember]
        [Column()]
        [DataMember]
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
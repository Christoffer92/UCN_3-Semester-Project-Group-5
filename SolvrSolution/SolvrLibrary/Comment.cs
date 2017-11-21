using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "comments")]
    [InheritanceMapping(Code = "Solvr", Type = typeof(SolvrComment))] //expects the Descriminator is a stype of string
    [InheritanceMapping(Code = "Comment", Type = typeof(Comment), IsDefault = true)]
    public class Comment
    {
        public Comment()
        {
            DateCreated = DateTime.Now;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public DateTime DateCreated { get; set; }

        [Column()]
        public string Text { get; set; }

        [Column()]
        public int UserId { get; set; }

        [Column()]        
        public int PostId { get; set; }

        //this wasnt af string but an int..... fixed it
        [Column(IsDiscriminator = true)]
        public string CommentType { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }

        public List<Vote> Votes { get; set; }

    }
}

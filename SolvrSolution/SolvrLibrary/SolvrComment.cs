using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "solvrcomments")]
    public class SolvrComment : Comment
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column()]
        public DateTime TimeAccepted { get; set; }
        [Column()]        
        public bool IsAccepted { get; set; }
        //[Column()]        
        //public int CommentId { get; set; }
        //[Column()]        
        //public int PhysicalPostId { get; set; }

        public PhysicalPost PhysicalPost { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "votes")]
    [DataContract]
    public class Vote
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [DataMember]
        public int Id { get; set; }

        [Column()]
        [DataMember]
        public bool IsUpvoted { get; set;}

        [Column()]
        [DataMember]
        public int UserId { get; set; }

        [Column()]
        [DataMember]
        public int CommentId { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Comment Comment { get; set; }

    

    }
}

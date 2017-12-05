using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [DataContract]
    [Table(Name = "reports")]
    public class Report
    {
        public Report()
        {
            DateCreated = DateTime.Now;
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
        public DateTime DateCreated { get; set; }

        [DataMember]
        [Column()]
        public int UserId { get; set; }

        [DataMember]
        [Column()]
        public int CommentId { get; set; }

        [DataMember]
        [Column()]
        public int PostId { get; set; }

        [DataMember]
        [Column()]
        public string ReportType { get; set; }

        [DataMember]
        [Column()]
        public bool IsResolved { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Comment Comment { get; set; }

        [DataMember]
        public Post Post { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "reports")]
    public class Report
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public string Title { get; set; }

        [Column()]
        public string Description { get; set; }

        [Column()]
        public DateTime DateCreated { get; set; }

        public User User { get; set; }

        public Comment Comment { get; set; }

        public Post Post { get; set; }
    }
}

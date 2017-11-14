using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public User ReportUser { get; set; }
        public Comment ReportedComment { get; set; }
        public Post ReportedPost { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

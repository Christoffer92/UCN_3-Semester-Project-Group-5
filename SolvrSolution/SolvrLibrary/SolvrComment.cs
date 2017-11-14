using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class SolvrComment : Comment
    {
        [Key]
        public int SolvrCommentID { get; set; }
        public PhysicalPost PPComment { get; set; }
        public DateTime TimeAccepted { get; set; }
        public bool IsAccepted { get; set; }
    }
}

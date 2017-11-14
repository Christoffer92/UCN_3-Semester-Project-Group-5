using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class SolvrComment : Comment
    {
        public PhysicalPost PPComment { get; set; }
        public DateTime TimeAccepted { get; set; }
        public bool IsAccepted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class PhysicalPost : Post
    {
        [Key]
        public int PhysicalID { get; set; }
        public bool Locked { get; set; }
        public string AltDescription { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
    }
}

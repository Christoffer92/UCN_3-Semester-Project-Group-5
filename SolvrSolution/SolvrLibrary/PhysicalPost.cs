using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    //[Table(Name = "physicalposts")]
    public class PhysicalPost : Post
    {
        /*[Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }*/
        [DataMember]
        [Column()]
        public bool IsLocked { get; set; }

        [DataMember]
        [Column()]
        public string AltDescription { get; set; }

        [DataMember]
        [Column()]
        public string Zipcode { get; set; }

        [DataMember]
        [Column()]
        public string Address { get; set; }

        /*public List<SolvrComment> SolvrComments { get; set; }*/

        /*[Column()]
        public int PostId { get; set; }*/
    }
}

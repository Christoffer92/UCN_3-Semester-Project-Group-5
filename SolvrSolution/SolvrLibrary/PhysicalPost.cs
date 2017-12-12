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
    public class PhysicalPost : Post
    {

        [Column()]
        [DataMember]
        public bool IsLocked { get; set; }

        [Column()]
        [DataMember]
        public string AltDescription { get; set; }

        [Column()]
        [DataMember]
        public string Zipcode { get; set; }

        [Column()]
        [DataMember]
        public string Address { get; set; }
    }
}

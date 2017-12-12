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
    public class SolvrComment : Comment
    {
        public SolvrComment()
        {
            TimeAccepted = DateTime.Now;
            IsAccepted = false;
        }

        [Column()]
        [DataMember]
        public DateTime TimeAccepted { get; set; }

        [Column()]
        [DataMember]
        public bool IsAccepted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "users")]
    [DataContract]
    public class User
    {
        public User()
        {
            DateCreated = DateTime.Now;
        }


        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [DataMember]
        public int Id { get; set; }

        [Column()]
        [DataMember]
        public string Name { get; set; }

        [Column()]
        [DataMember]
        public string Email { get; set; }

        [Column()]
        [DataMember]
        public string Username { get; set; }

        [Column()]
        [DataMember]
        public string Password { get; set; }

        [Column()]
        [DataMember]
        public bool IsAdmin { get; set; }

        [Column()]
        [DataMember]
        public DateTime DateCreated { get; set; }

        [Column()]
        [DataMember]
        public bool IsDisabled { get; set; }
    }
}

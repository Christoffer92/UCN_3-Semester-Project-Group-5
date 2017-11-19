using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    [Table(Name = "users")]
    public class User
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public string Name { get; set; }

        [Column()]
        public string Email { get; set; }

        [Column()]
        public string Username { get; set; }

        [Column()]
        public string Password { get; set; }

        [Column()]
        public bool IsAdmin { get; set; }

        [Column()]
        public DateTime DateCreated { get; set; }

        public List<Post> Posts { get; set; }
        
    }
}

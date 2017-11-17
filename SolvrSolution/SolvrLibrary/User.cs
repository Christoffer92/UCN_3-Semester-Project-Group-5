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
        public User(string _name, string _email, string _username, string _password)
        {
            Id = 0;
            Name = _name;
            Email = _email;
            UserName = _username;
            Password = _password;
            IsAdmin = false;
            DateCreated = new DateTime();
            Posts = new List<Post>();
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column()]
        public string Name { get; set; }

        [Column()]
        public string Email { get; set; }

        [Column()]
        public string UserName { get; set; }

        [Column()]
        public string Password { get; set; }

        [Column()]
        public bool IsAdmin { get; set; }

        [Column()]
        public DateTime DateCreated { get; set; }

        public List<Post> Posts { get; set; }
        
    }
}

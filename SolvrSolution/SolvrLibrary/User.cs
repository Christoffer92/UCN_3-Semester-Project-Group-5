using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolvrLibrary
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public List<Post> Posts { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AdminUser { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

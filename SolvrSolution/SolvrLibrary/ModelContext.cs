using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SolvrLibrary
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("ModelContext")
        {

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<PhysicalPost> PhysicalPosts { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<SolvrComment> SolvrComments { get; set; }
        public DbSet<User> Users { get; set; }
        DbSet<Vote> Votes { get; set; }
    }
}

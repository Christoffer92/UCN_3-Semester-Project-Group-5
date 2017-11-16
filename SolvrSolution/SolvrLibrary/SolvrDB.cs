using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    class SolvrDB : DataContext
    {
        public Table<Post> Posts;
        public Table<User> Users;
        public Table<Comment> Comments;
        public Table<Category> Categories;
        public Table<Report> Reports;
        public Table<SolvrComment> SolvrComments;
        public Table<Vote> Votes;
        public Table<PhysicalPost> PhysicalPosts;

        public SolvrDB(string connection) : base(connection){ }
    }
}

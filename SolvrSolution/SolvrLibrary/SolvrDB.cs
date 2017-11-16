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
        //Here is the tables for the project. These tables are in the database.
        public Table<Post> Posts;
        public Table<User> Users;
        public Table<Comment> Comments;
        public Table<Category> Categories;
        public Table<Report> Reports;
        public Table<SolvrComment> SolvrComments;
        public Table<Vote> Votes;
        public Table<PhysicalPost> PhysicalPosts;

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that createse a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        public SolvrDB(string connection) : base(connection){ }
    }
}

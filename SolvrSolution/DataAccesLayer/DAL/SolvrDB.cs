using DataAccesLayer.ModelBuilds;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class SolvrDB : DataContext, ISolvrDB
    {
        //Here are the tables for the project. These tables are in the database.
        public Table<Post> Posts { get; private set; }
        public Table<User> Users { get; private set; }
        public Table<Comment> Comments { get; private set; }
        public Table<Category> Categories { get; private set; }
        public Table<Report> Reports { get; private set; }
        public Table<SolvrComment> SolvrComments { get; private set; }
        public Table<Vote> Votes { get; private set; }
        public Table<PhysicalPost> PhysicalPosts { get; private set; }

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that creates a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        public SolvrDB(string connection = "") : base(connection) { }

        //Queries after this:
        public Category GetCategory(int id)
        {
            return new ModelBuilder().BuildCategory(id);
        }

        public Category GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void CreatePhysicalPost(PhysicalPost pPost)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            return new ModelBuilder().BuildPost<Post>(id);
        }

        public Post GetPost()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }
        public User GetUser(int id) 
        {
            return new ModelBuilder().BuildUser(id);
        }
    }
}

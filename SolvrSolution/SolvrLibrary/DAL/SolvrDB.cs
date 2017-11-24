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
        private Table<Post> Posts;
        private Table<User> Users;
        private Table<Comment> Comments;
        private Table<Category> Categories;
        private Table<Report> Reports;
        private Table<SolvrComment> SolvrComments;
        private Table<Vote> Votes;
        private Table<PhysicalPost> PhysicalPosts;

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that creates a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        public SolvrDB(string connection = "") : base(connection) { }

        //Queries after this:
        public void CreatePhysicalPost(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            throw new NotImplementedException();
        }

        public PhysicalPost GetLastPhysicalPost()
        {
            throw new NotImplementedException();
        }

        public void CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList)
        {
            throw new NotImplementedException();
        }

        public Post GetLastPost()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

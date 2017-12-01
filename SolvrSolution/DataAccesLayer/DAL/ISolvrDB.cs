using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public interface ISolvrDB
    {
        //    void CreatePhysicalPost(User expectedUser, string expectedTitle, string expectedDescription, Category expectedCategory, List<string> expectedTagsList, string expectedAltDescription, string expectedZipcode, string expectedAddress);
        //    PhysicalPost GetLastPhysicalPost();
        //    void CreatePost(User expectedUser, string expectedPostTitle, string expectedPostDescription, Category expectedCategory, List<string> expectedTagsList);
        //    Post GetLastPost();
        //    IEnumerable<Category> GetAllCategories();
        //    void CreatePost(Post post);
        //    Category GetCategoryById(int id);

        /// <summary>
        /// Returns a category, by searching for its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        Category GetCategory(int id);

        /// <summary>
        /// Returns a category, by searching for its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Category</returns>
        Category GetCategory(string name);

        /// <summary>
        /// Creates a Post and inserts it into the database, by giving it a foreign post
        /// with attributes attached to it
        /// </summary>
        /// <param name="post"></param>
        Post CreatePost(Post post);
        

        /// <summary>
        /// Creates a Physical Post and inserts it into the database, by giving it a foreign physical post
        /// with attributes attached to it
        /// </summary>
        /// <param name="pPost"></param>
        PhysicalPost CreatePhysicalPost(PhysicalPost Post);
        PhysicalPost GetPhysicalPost(int id);

        /// <summary>
        /// Returns a post with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Post GetPost(int id);

        /// <summary>
        /// Returns the last post that was inserted into the database.
        /// </summary>
        /// <returns>Post</returns>
        Post GetPost();


        /// Returns the last user that was inserted into the database.
        /// </summary>
        /// <returns>User</returns>
        User GetUser();


        /// <summary>
        /// Returns all Categories from the database
        /// </summary>
        /// <returns>List of Categories</returns>
        IEnumerable<Category> GetAllCategories();

        //TODO summary here
        User GetUser(int userId);
        IEnumerable<Comment> GetComments(int iD);
        Comment CreateComment(Comment c);
        SolvrComment CreateSolvrComment(SolvrComment sc);
    }
}

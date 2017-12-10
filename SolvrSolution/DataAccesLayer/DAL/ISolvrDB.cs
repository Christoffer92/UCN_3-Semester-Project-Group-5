using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.DAL
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

        void SetReportToResolved(int reportId);
        void UpdatePostText(int postId, string txt);

        /// <summary>
        /// Returns a category, by searching for its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Category</returns>
        Category GetCategory(string name);
        void DisablePost(int postId);
        void UpdatePostTilte(int postId, string text);

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
        /// Returns a report with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Report GetReport(int id);

        /// <summary>
        /// Returns a user with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(int id);

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

        /// <summary>
        /// Returns all Reports from the database
        /// </summary>
        /// <returns>List of Reports</returns>
        List<Report> GetAllReports();


        /// <summary>
        /// Creates a Report and inserts it into the database, by giving it a foreign report
        /// with attributes attached to it
        /// </summary>
        /// <param name="report"></param>
        Report CreateReport(Report report);

        /// <summary>
        /// Creates a Vote and inserts it into the database, by giving it a foreign vote
        /// with attributes attached to it
        /// </summary>
        /// <param name="vote"></param>
        Vote CreateVote(Vote vote);

        //TODO summary and cleanup
        IEnumerable<Comment> GetComments(int iD);
        Comment CreateComment(Comment c);
        SolvrComment CreateSolvrComment(SolvrComment sc);
        void UpdatePost(Post p);
        void UpdateSolvrComment(SolvrComment sc);
        T GetComment<T>(int ID);
        void UpdatePhysicalPost(PhysicalPost post);
        IEnumerable<Post> GetPostsByBumpTime(int loadCount);
        User GetUser(string Email);

        

        bool DatabaseExists();
    }
}

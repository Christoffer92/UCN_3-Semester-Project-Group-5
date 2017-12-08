using SolvrLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SolvrServices
{
    [ServiceContract]
    public interface ISolvrServices
    {
        /// <summary>
        /// Returns all Reports from the database
        /// </summary>
        /// <returns>List of Reports</returns>
        [OperationContract]
        List<Report> GetAllReports();

        /// <summary>
        /// Returns a report with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Report GetReport(int id);

        /// <summary>
        /// Returns a user with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Name = "GetUserUsingId")]
        User GetUser(int id);

        [OperationContract]
        bool IsConnectedToDatabase();

        [OperationContract]
        void SetReportToResolved(int reportId);

        [OperationContract]
        void UpdatePostText(int postId, string txt);

        [OperationContract]
        void DisablePost(int postId);

        [OperationContract]
        void UpdatePostTitle(int postId, string text);

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
        [OperationContract]
        Category GetCategory(string name);

        /// <summary>
        /// Creates a Post and inserts it into the database, by giving it a foreign post
        /// with attributes attached to it
        /// </summary>
        /// <param name="post"></param>
        [OperationContract]
        Post CreatePost(Post post);

        /// <summary>
        /// Creates a Physical Post and inserts it into the database, by giving it a foreign physical post
        /// with attributes attached to it
        /// </summary>
        /// <param name="pPost"></param>
        [OperationContract]
        PhysicalPost CreatePhysicalPost(PhysicalPost post);

        [OperationContract]
        PhysicalPost GetPhysicalPost(int id);

        /// <summary>
        /// Returns a post with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Name = "GetPostUsingId")]
        Post GetPost(int id);

        /// <summary>
        /// Returns the last post that was inserted into the database.
        /// </summary>
        /// <returns>Post</returns>
        [OperationContract(Name = "GetPostNothing")]
        Post GetPost();

        /// Returns the last user that was inserted into the database.
        /// </summary>
        /// <returns>User</returns>
        [OperationContract(Name = "GetUserNothing")]
        User GetUser();

        /// <summary>
        /// Returns all Categories from the database
        /// </summary>
        /// <returns>List of Categories</returns>
        [OperationContract]
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Returns all comments from the database
        /// </summary>
        /// <param name="iD"></param>
        /// <returns>List of comments</returns>
        [OperationContract]
        IEnumerable<Comment> GetComments(int iD);

        /// <summary>
        /// Creates a comment and inserts it into the database, by giving it a foreign comment
        /// with attributes attached to it
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [OperationContract]
        Comment CreateComment(Comment c);

        //TODO summary and cleanup

        [OperationContract]
        SolvrComment CreateSolvrComment(SolvrComment sc);

        [OperationContract]
        void UpdatePost(Post p);

        [OperationContract]
        void UpdateSolvrComment(SolvrComment sc);

        [OperationContract(Name = "GetSolvrCommentUsingID")]
        SolvrComment GetSolvrComment(int ID);

        [OperationContract(Name = "GetCommentUsingID")]
        Comment GetComment(int ID);

        [OperationContract]
        void UpdatePhysicalPost(PhysicalPost post);

        [OperationContract]
        IEnumerable<Post> GetPostsByBumpTime(int loadCount);

        [OperationContract(Name = "GetUserUsingName")]
        User GetUser(string Username);

        [OperationContract]
        void CreateUser(User user);
    }
}
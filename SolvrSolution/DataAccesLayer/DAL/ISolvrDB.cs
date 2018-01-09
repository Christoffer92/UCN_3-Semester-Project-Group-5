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
        /// Returns true if the database exists.
        /// </summary>
        /// <returns>bool</returns>
        bool DatabaseExists();

        #region Get Methods

        /// Returns the user with the specified username.
        /// </summary>
        /// <returns>User</returns>
        User GetUser(string username);

        /// <summary>
        /// Returns a user with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        User GetUser(int id);

        /// <summary>
        /// Returns a post with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post</returns>
        Post GetPost(int id);

        /// <summary>
        /// Returns a comment, by searching for its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comment</returns>
        Comment GetComment(int id);

        /// <summary>
        /// Returns a category, by searching for its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        Category GetCategory(int id);

        /// <summary>
        /// Returns a report with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Report</returns>
        Report GetReport(int id);

        /// <summary>
        /// Returns a list of posts sorted by bumptime.
        /// </summary>
        /// <param name="offSet"></param>
        /// <param name="loadCount"></param>
        /// <returns>List<Post></returns>
        List<Post> GetPostList(int offSet, int loadCount);

        /// <summary>
        /// Returns a list of comments on the specifed post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>List<Post></returns>
        List<Comment> GetCommentList(int postId);

        /// <summary>
        /// Returns a list of reports thats resolved or a list of reports thats not resolved.
        /// </summary>
        /// <param name="onlyNotResolved"></param>
        /// <returns>List<Report></returns>
        List<Report> GetReportList(bool onlyNotResolved);

        /// <summary>
        /// Returns a list of all categories.
        /// </summary>
        /// <returns>List<Category></returns>
        List<Category> GetCategoryList();

        /// <summary>
        /// Returns a list of all votes on specified comment
        /// </summary>
        /// <returns>List<Vote></returns>
        List<Vote> GetVoteList(int commentId);
        #endregion

        #region Insert Methods

        /// <summary>
        /// Inserts the specified Post into the Database and returns the post with an updated Id
        /// </summary>
        /// <returns>Post</returns>
        Post InsertPost(Post post);

        /// <summary>
        /// Inserts the specified User into the Database and returns the user with an updated Id
        /// </summary>
        /// <returns>User</returns>
        User InsertUser(User user);

        /// <summary>
        /// Inserts the specified Report into the Database and returns the Report with an updated Id
        /// </summary>
        /// <returns>Report</returns>
        Report InsertReport(Report report);

        /// <summary>
        /// Inserts the specified Comment into the Database and returns the Comment with an updated Id
        /// </summary>
        /// <returns>Comment</returns>
        Comment InsertComment(Comment comment);
        #endregion

        #region Update Methods

        /// <summary>
        /// Updates a specified post and returns it.
        /// </summary>
        /// <param name="Post"></param>
        Post UpdatePost(Post post);

        /// <summary>
        /// Updates a specified Report and returns it.
        /// </summary>
        /// <param name="Report"></param>
        Report UpdateReport(Report report);

        /// <summary>
        /// Updates a specified Comment and returns it.
        /// </summary>
        /// <param name="Comment"></param>
        Comment UpdateComment(Comment comment);
        #endregion

        #region Async Methods

        /// <summary>
        /// Returns a list of posts sorted by bumptime.
        /// </summary>
        /// <param name="offSet"></param>
        /// <param name="loadCount"></param>
        /// <returns>List<Post></returns>
        Task<List<Post>> GetPostListAsync(int offSet, int loadCount);

        /// <summary>
        /// Returns a category, by searching for its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        Task<Category> GetCategoryAsync(int id);

        /// <summary>
        /// Returns a user with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        Task<User> GetUserAsync(int id);

        /// Returns the user with the specified username.
        /// </summary>
        /// <returns>User</returns>
        Task<User> GetUserAsync(string username);

        /// <summary>
        /// Returns a list of comments on the specifed post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>List<Post></returns>
        Task<List<Comment>> GetCommentListAsync(int postId);
        #endregion
    }
}
